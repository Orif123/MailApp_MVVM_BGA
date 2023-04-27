using MailApp.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Test.Client.Test.ViewModels
{
    [TestClass]
    public class ViewModelLocatorTest
    {
        [TestMethod]
        public void ViewModelLocator_ShouldResolveMailDashboardViewModel()
        {
            // Arrange
            var locator = new ViewModelLocator();

            // Act
            var mailDashboardViewModel = locator.MailDashboardViewModel;

            // Assert
            Assert.IsNotNull(mailDashboardViewModel);
        }
    }
}
