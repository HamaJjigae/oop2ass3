using NUnit.Framework;
using Assignment3;
using System.IO;

namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private ILinkedListADT users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
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

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.That(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);
            
            Assert.That(users.Count() == deserializedUsers.Count());
            
            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.That(actual.Id, Is.EqualTo(expected.Id));
                Assert.That(actual.Name, Is.EqualTo(expected.Name));
                Assert.That(actual.Email, Is.EqualTo(expected.Email));
                Assert.That(actual.Password, Is.EqualTo(expected.Password));
            }
        }
    }
}