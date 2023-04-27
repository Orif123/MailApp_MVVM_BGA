using MailApp.Domain.Models;
using MailApp.Domain.Service;
using MailApp.Client.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Test.Client.Test.ViewModels
{
    [TestClass]
    public class MailDashboardViewModelTest
    {
        [TestMethod]
        public void Filter_CheckIfReturnDesiredEntities()
        {
            var mockMailRepository = new Mock<IRepository<Mail>>();
            var demoMails = new List<Mail>
    {
        new Mail { User = new User { Username = "John" }, Date = new DateTime(2022, 01, 01) },
        new Mail { User = new User { Username = "Alice" }, Date = new DateTime(2022, 01, 02) },
        new Mail { User = new User { Username = "Bob" }, Date = new DateTime(2022, 01, 03) },
        new Mail { User = new User { Username = "John" }, Date = new DateTime(2022, 01, 04) },
    };
            mockMailRepository.Setup(m => m.GetAll()).Returns(demoMails);
            var viewModel = new MailDashboardViewModel(mockMailRepository.Object);

            // Act
            viewModel.Filter = "John";

            // Assert
            Assert.AreEqual(2, viewModel.Mails.Cast<Mail>().Count());
            Assert.IsTrue(viewModel.Mails.Cast<Mail>().All(m => m.User.Username.Contains("John")));
        }

    }
}
