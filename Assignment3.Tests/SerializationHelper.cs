using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            List<User> userList = ConvertToUserList(users);

            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, userList);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.OpenRead(fileName))
            {
                List<User> userList = (List<User>)serializer.ReadObject(stream);
                return ConvertToLinkedList(userList);
            }
        }
        private static List<User> ConvertToUserList(ILinkedListADT linkedList)
        {
            List<User> userList = new List<User>();
            for (int i = 0; i < linkedList.Count(); i++)
            {
                userList.Add(linkedList.GetValue(i));
            }
            return userList;
        }
        private static ILinkedListADT ConvertToLinkedList(List<User> userList)
        {
            ILinkedListADT linkedList = new SLL();
            foreach (User user in userList)
            {
                linkedList.AddLast(user);
            }
            return linkedList;
        }
    }
}