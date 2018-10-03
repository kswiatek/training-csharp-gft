﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TrainingCsharpGft.Api;
using TrainingCsharpGft.Api.Model;

namespace TrainingCsharpGft.Tests.Model
{
    class AccountsManagerTests
    {
        private IStore storage;
        
        [SetUp]
        public void TestSetUp()
        {
            storage = new AccountsManager();
        }

        [Test]
        public void AccountsManagerShouldPersistAccountOnPut()
        {
            //Arrange
            var testAccount = new Account { Name = "test1"};
            //Act
            storage.Put(testAccount);
            //Assert
            Assert.AreEqual(testAccount, storage.Get(testAccount.Name));
        }

        [Test]
        public void AccountsManagerShouldReturnAllAccountsOnGetAllAccounts()
        {
            var testAccount1 = new Account { Name = "test1" };
            var testAccount2 = new Account { Name = "test2", Ballance = 200 };
            var testAccount3 = new Account { Name = "test3" };

            storage.Put(testAccount1);
            storage.Put(testAccount2);
            storage.Put(testAccount3);

            CollectionAssert.Contains(storage.GetAllAccounts(), testAccount1);
            CollectionAssert.Contains(storage.GetAllAccounts(), testAccount2);
            CollectionAssert.Contains(storage.GetAllAccounts(), testAccount3);
        }

        [Test]
        public void AccountsManagerShouldDeleteSpecifiedAccountOnDelete()
        {
            var testAccount1 = new Account { Name = "test1" };
            var testAccount2 = new Account { Name = "test2", Ballance = 200 };
            var testAccount3 = new Account { Name = "test3" };

            storage.Put(testAccount1);
            storage.Put(testAccount2);
            storage.Put(testAccount3);
            storage.Delete("test2");

            CollectionAssert.Contains(storage.GetAllAccounts(), testAccount1);
            CollectionAssert.DoesNotContain(storage.GetAllAccounts(), testAccount2);
            CollectionAssert.Contains(storage.GetAllAccounts(), testAccount3);
        }

    }
}