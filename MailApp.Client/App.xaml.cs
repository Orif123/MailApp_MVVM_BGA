using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MailApp.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static MainWindow app;
        public App()
        {
            Startup += Application_Startup;
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
           

            EventManager.RegisterClassHandler(
                typeof(TextBox), TextBox.GotFocusEvent, new RoutedEventHandler(TextBox_GotFocus));
            EventManager.RegisterClassHandler(
                typeof(TextBox), TextBox.PreviewMouseDownEvent, new RoutedEventHandler(TextBox_PreviewMouseDown));

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            // For catching Global uncaught exception
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionOccured);

            // Load database stuff
            app = new MainWindow();
            //app.Show();
        }

        private static void UnhandledExceptionOccured(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
        }

       

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //Log.Debug("Register Class Handler TextBox GotFocus");
            (sender as TextBox).SelectAll();
        }

        private void TextBox_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            //Log.Debug("Register Class Handler TextBox PreviewMouseDown");
            TextBox textBox = sender as TextBox;
            if (!textBox.IsFocused)
            {
                textBox.Focus();
                textBox.SelectAll();
                e.Handled = true;
            }
        }
    }
}
