using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Utility;
using System.Reflection.Metadata;
using System.Runtime.Serialization;

namespace Assignment3.Tests
{
    public class SLLTest
    {
        private SLL users;
        [SetUp]
        public void Setup()
        {
            users = new SLL();
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
        public void TestPrepends()
        {
            var test = new SLL();
            var value = new User(1, "Joe Blow", "jblow@gmail.com", "password");

            test.AddFirst(value);
            var prepended = test.GetValue(0);

            Assert.AreEqual(value, prepended);


        }

        [Test]

        public void TestContains()
        {
            SLL users = new SLL();
            User userExist = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            users.AddLast(userExist);

   
            Assert.IsTrue(users.Contains(userExist));
        }


        [Test]
        public void TestClear()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        

        users.Clear();

            Assert.That(users.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestCount()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            Assert.AreEqual(4, users.Count());
        }

        [Test]
        public void TestGetValue()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));

            User user3 = users.GetValue(2);
            Assert.AreEqual("Colonel Sanders", user3.Name);
            Assert.AreEqual("kfc5555", user3.Password);
            Assert.AreEqual(3, user3.Id);
            Assert.AreEqual("chickenlover1890@gmail.com", user3.Email);

        }


        [Test]
        public void TestIndexOf()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            int indexUser1 = users.IndexOf(new User(1, "Joe Blow", "jblow@gmail.com", "password")); 

            Assert.That(indexUser1, Is.EqualTo(0));
        }
        [Test]
        public void TestIsEmpty()
        {
            SLL test = new SLL();

            bool result = test.IsEmpty();

            Assert.IsTrue(result);
        }

        [Test]

        public void isAppended()
        {
            SLL test = new SLL();

            var user = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");

            test.AddLast(user);
            var apended = test.GetValue(0);
            Assert.AreEqual(user, apended);

        }

        [Test]
        public void TestAdd()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));

            User addedUser = new User (4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            int i = 1;
            users.Add(addedUser, i);
            Assert.AreEqual(addedUser, users.GetValue(i));
        }

        [Test]
        public void TestAddFirst() 
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));

            var addFirstUser = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");

            users.AddFirst(addFirstUser);
            var current = users.Head;
            Assert.AreEqual(addFirstUser, current.Value);
          
        }
        [Test]
        public void TestAddLast()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));

            var addLastUser = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            users.AddLast(addLastUser);

            var current = users.Head;
            while (current.Next != null)
            {
                current= current.Next;
            }

            Assert.AreEqual(addLastUser, current.Value);
        }

        [Test]
        public void TestRemove()
        {
            SLL users = new SLL();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            
            users.Remove(2);

            Assert.IsFalse(users.Contains(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555")));
            Assert.AreEqual(3 , users.Count());
        }

        [Test]
        public void TestRemoveFirst()
        {

            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            int initalCount = users.Count();
            users.RemoveFirst();

            Assert.IsFalse(users.Contains(new User(1, "Joe Blow", "jblow@gmail.com", "password")));
            Assert.AreEqual(initalCount - 1, users.Count());

        }

        [Test]
        public void TestRemoveLast() 
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            int initalCount = users.Count();
            users.RemoveLast();

            Assert.IsFalse(users.Contains(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999")));
            Assert.AreEqual(initalCount -1 , users.Count());

        }

        [Test]
        public void TestReplace()
        {
            SLL users = new SLL();
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));

            int initalCount = users.Count();
            User replacingUser = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            users.Replace(replacingUser, 1);

            Assert.IsTrue(users.Contains(replacingUser));
            Assert.IsFalse(users.Contains(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef")));
            Assert.AreEqual(initalCount, users.Count());
        }

        [Test]
        public void TestAddToArray ()
        {
            SLL users = new SLL();

            var user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            var user2 = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            var user3 = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");

            users.AddLast(user1);
            users.AddLast(user2);
            users.AddLast(user3);

            List<string> unlinked = users.AddToArray();

            Assert.AreEqual(unlinked[0], user1.ToString());
            Assert.AreEqual(unlinked[1], user2.ToString());
            Assert.AreEqual(unlinked[2], user3.ToString());


        }

       

    }
}           
