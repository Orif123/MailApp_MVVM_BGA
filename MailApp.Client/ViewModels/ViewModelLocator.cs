using Autofac;
using MailApp.Models.Data;
using MailApp.Models.Models;
using MailApp.Models.Service;
using MailApp.ViewModel.ViewModels;

namespace MailApp.Views.ViewModels
{
    public class ViewModelLocator
    {
        #region Fields
        private static readonly IContainer container;
        private static  DemoDataContext demoDataContext;
        #endregion
        #region Dependency Injection
        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

           demoDataContext = new DemoDataContext();
            var mails = demoDataContext.Mails;

            //Single Instance AKA Singleton!
            builder.RegisterInstance(mails).SingleInstance();
            builder.RegisterType<Repository<Mail>>().As<IRepository<Mail>>().SingleInstance();

            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<SplashViewModel>().SingleInstance();
            builder.RegisterType<MailDashboardViewModel>().SingleInstance();

            container = builder.Build();
        }
        #endregion
        #region Properties
        public MainViewModel MainViewModel => container.Resolve<MainViewModel>();
        public SplashViewModel SplashViewModel => container.Resolve<SplashViewModel>();
        public MailDashboardViewModel MailDashboardViewModel => container.Resolve<MailDashboardViewModel>();
        #endregion
    }
}
