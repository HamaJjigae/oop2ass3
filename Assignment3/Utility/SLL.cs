using Assignment3.Utility;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace Assignment3
{
    [DataContract]
    [KnownType(typeof(Node))]
    public class SLL : ILinkedListADT
    {
        [DataMember]
        private Node head;
        [DataMember]
        private Node tail;
        [DataMember]
        private int count;

        public SLL()
        {
            head = null;
            tail = null;
            count = 0;
        }

        //checks for SLL to be empty, returns F or T depending on result.
        public bool IsEmpty()
        {
            if (head == null) return true;
            else { return false; }
        }


        //clears all nodes. This could just be done with head/tail but I wanted to remove resources.
        public void Clear()
        {
            Node current = head;
            while (current != null)
            {
                Node next = current.Next;
                current.Next = null;
                current = next;
            }
            head = null;
            tail = null;
            count = 0;
        }

        //this checks if there's something in the list and then adds it to the tail
        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            count++;
        }

        //this checks if there's something in the list and then adds it to the head
        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
        }

        //this checks if the index is valid and then adds it to the indexed location by re-assigning the next values.
        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == count)
            {
                AddLast(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                count++;
            }
        }

        //this checks if the index value is valid and then replaces the node at the index with a new node.
        public void Replace(User value, int index)
        {
            if (index < 0 || index > count - 1)
                throw new IndexOutOfRangeException();
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }

        //returns count
        public int Count()
        {
            return count;
        }

        //removes first node while trying to garbage collect as little as possible
        public void RemoveFirst()
        {
            if (head == null)
                throw new CannotRemoveException();
            Node nodeRemove = head;
            head = head.Next;

            if (head == null)
            {
                tail = null;
            }
            nodeRemove.Next = null;
            nodeRemove = null;
            count--;
        }

        //this removes the last node. I couldn't find a way to remove this more efficiently so it is the way it is.
        public void RemoveLast()
        {
            if (tail == null)
                throw new CannotRemoveException();
            if (head.Next == null)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node current = head;

                for (int i = 0; i < count - 2; i++)
                {
                    current = current.Next;
                }
                current.Next = null;
                tail = current;
            }
            count--;
        }

        //this removes the node at the index given. it should be an efficient garbage collection.
        public void Remove(int index)
        {
            if (index < 0 || index > count - 1)
                throw new IndexOutOfRangeException();
            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == count - 1)
            {
                RemoveLast();
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                Node nodeRemove = current.Next;
                current.Next = current.Next.Next;
                if (current.Next == null)
                {
                    tail = current;
                }
                nodeRemove.Next = null;
                nodeRemove = null;
                count--;
            }
        }

        //this checks for the value at the index given and returns the value. it also covers the easy cases of tail and head.
        public User GetValue(int index)
        {
            if (index < 0 || index > count - 1)
                throw new IndexOutOfRangeException();
            if (index == 0)
            {
                return head.Value;
            }
            else if (index == count - 1)
            {
                return tail.Value;
            }
            else
            {
                Node current = head.Next;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }
        }

        //this checks for the index for the given value if it exists and if not returns -1. This also covers tail and head.
        public int IndexOf(User value)
        {
            if (value == head.Value)
            {
                return 0;
            }
            else if (value == tail.Value)
            {
                return count - 1;
            }
            else
            {
                Node current = head.Next;

                for (int i = 1; i < count; i++)
                {
                    if (current.Value.Equals(value))
                    {
                        return i;
                    }
                    current = current.Next;
                }
            }
            return -1;
        }

        //this checks if the value is in the SLL and then returns T or F
        public bool Contains(User value)
        {
            if (head == null)
            {
                return false;
            }
            if (head.Value.Equals(value))
            {
                return true;
            }
            else
            {
                Node current = head.Next;
                for (int i = 1; i < count; i++)
                {
                    if (current.Value.Equals(value))
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
        }

        //this reverses the order of the nodes
        public void Reverse()
        {
            if (head == null)
            {
                return;
            }

            Node previous = null;
            Node current = head;
            Node next = null;

            tail = head;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }
    }
}