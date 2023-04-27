using GalaSoft.MvvmLight;
using MailApp.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private object currentViewModel;
        
        #endregion
        #region Properties
        public object CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                RaisePropertyChanged(nameof(CurrentViewModel));
            }
        }

        #endregion
        #region Constructor
        public MainViewModel()
        {
            SplashViewModel.OnSwitchView += SwitchToMainView;
        }
        #endregion
        #region Methods

        public void SwitchToMainView()
        {
            if (this != null)
                CurrentViewModel = this;
            else
                CurrentViewModel = new MainViewModel();
        }


        #endregion
    }

}

