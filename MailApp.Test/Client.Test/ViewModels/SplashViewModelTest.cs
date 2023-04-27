using MailApp.Views.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailApp.Test.Client.Test.ViewModels
{
    [TestClass]
    public class SplashViewModelTest
    {
        [TestMethod]
        public void Worker_ProgressCounterUpdatesCorrectly()
        {
            // Arrange
            var viewModel = new SplashViewModel();
            var progressCounterValues = new List<int>();

            // Act
            // Wait for the background operation to complete and collect the progress counter values
            while (viewModel.BarVisibillity == Visibility.Visible)
            {
                progressCounterValues.Add(viewModel.ProgressCounter);
                Thread.Sleep(100);
            }

            // Assert
            // Check if the progress counter values are in the expected range of 0 to 100
            Assert.IsTrue(progressCounterValues.All(value => value >= 0 && value <= 100));
        }
    }
}
