using NUnit.Framework;
using Assignment3;
using System;

namespace Assignment3.Tests
{
    public class LinkedListTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            this.users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        [Test]
        public void TestIsEmptyWhenListIsEmpty()
        {
            ILinkedListADT emptyList = new SLL();
            Assert.That(emptyList.IsEmpty(), Is.True);
        }

        [Test]
        public void TestIsEmptyWhenListIsNotEmpty()
        {
            Assert.That(users.IsEmpty(), Is.False);
        }

        [Test]
        public void TestAddFirst()
        {
            var newUser = new User(5, "New User", "newuser@example.com", "newpassword");
            users.AddFirst(newUser);
            Assert.That(users.GetValue(0), Is.EqualTo(newUser));
        }

        [Test]
        public void TestAddLast()
        {
            var newUser = new User(6, "Another User", "anotheruser@example.com", "anotherpassword");
            users.AddLast(newUser);
            Assert.That(users.GetValue(users.Count() - 1), Is.EqualTo(newUser));
        }

        [Test]
        public void TestAddAtIndex()
        {
            var newUser = new User(7, "Inserted User", "inserteduser@example.com", "insertedpassword");
            users.Add(newUser, 2);
            Assert.That(users.GetValue(2), Is.EqualTo(newUser));
        }

        [Test]
        public void TestReplace()
        {
            var newUser = new User(8, "Replaced User", "replaceduser@example.com", "replacedpassword");
            users.Replace(newUser, 1);
            Assert.That(users.GetValue(1), Is.EqualTo(newUser));
        }

        [Test]
        public void TestRemoveFirst()
        {
            users.RemoveFirst();
            Assert.That(users.GetValue(0).Name, Is.EqualTo("Joe Schmoe"));
        }

        [Test]
        public void TestRemoveLast()
        {
            users.RemoveLast();
            Assert.That(users.GetValue(users.Count() - 1).Name, Is.EqualTo("Colonel Sanders"));
        }

        [Test]
        public void TestRemoveAtIndex()
        {
            users.Remove(1);
            Assert.That(users.GetValue(1).Name, Is.EqualTo("Colonel Sanders"));
        }

        [Test]
        public void TestRemoveAtInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => users.Remove(-1));
            Assert.Throws<IndexOutOfRangeException>(() => users.Remove(users.Count()));
        }

        [Test]
        public void TestGetValueAtInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => users.GetValue(-1));
            Assert.Throws<IndexOutOfRangeException>(() => users.GetValue(users.Count()));
        }

        [Test]
        public void TestFindAndRetrieve()
        {
            User userToFind = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            Assert.That(users.IndexOf(userToFind), Is.EqualTo(2));
        }

        [Test]
        public void TestContains()
        {
            User userToFind = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            Assert.That(users.Contains(userToFind), Is.True);
        }

        [Test]
        public void TestContainsWhenNotInList()
        {
            User userToFind = new User(999, "Nonexistent User", "nonexistent@example.com", "nopassword");
            Assert.That(users.Contains(userToFind), Is.False);
        }

        [Test]
        public void TestReverse()
        {
            users.Reverse();

            Assert.That(users.GetValue(0).Name, Is.EqualTo("Ronald McDonald"));
            Assert.That(users.GetValue(1).Name, Is.EqualTo("Colonel Sanders"));
            Assert.That(users.GetValue(2).Name, Is.EqualTo("Joe Schmoe"));
            Assert.That(users.GetValue(3).Name, Is.EqualTo("Joe Blow"));
        }
    }
}