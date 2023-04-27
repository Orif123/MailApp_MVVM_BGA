using MailApp.Models.Data;
using MailApp.Models.Models;
using MailApp.Models.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Test.Domain.Test.Service
{
    [TestClass]
    public class ServiceTest
    {
        private ObservableCollection<Mail> entities;
        private IRepository<Mail> repository;
        [TestInitialize]
        public void Setup()
        {
            entities = new ObservableCollection<Mail>();
            repository = new Repository<Mail>(entities);
        }
        [TestMethod]
        public void AddMail_AddsNewMailToRepository()
        {
            // Arrange
            var demoDataContext = new DemoDataContext();
            var mailRepository = new Repository<Mail>(demoDataContext.Mails);
            var newMail = new Mail { ID = Guid.NewGuid(), Date = DateTime.Now, Subject = "New Mail", Content = "This is a new mail.", UserId = demoDataContext.Users.First().ID, User = demoDataContext.Users.First() };

            // Act
            mailRepository.Add(newMail);

            // Assert
            Assert.IsTrue(demoDataContext.Mails.Contains(newMail));
        }
        [TestMethod]
        public void GetAll_ReturnsAllEmails()
        {
            // Arrange
            var demoDataContext = new DemoDataContext();
            var expectedCount = demoDataContext.Mails.Count;
            var repository = new Repository<Mail>(demoDataContext.Mails);

            // Act
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(result.Count(), expectedCount);
        }
    }
}
