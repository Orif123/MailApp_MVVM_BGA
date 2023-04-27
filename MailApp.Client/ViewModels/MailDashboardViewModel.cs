using GalaSoft.MvvmLight;
using MailApp.Models.Models;
using MailApp.Models.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MailApp.ViewModel.ViewModels
{
    public class MailDashboardViewModel : ViewModelBase
    {
        #region Fields
        private BackgroundWorker worker = new BackgroundWorker();
        private readonly IRepository<User> userRepoistory;
        private readonly IRepository<Mail> mailRepository;
        private Mail selectedMail;
        private string filter;
        private bool isSortedAscending;
        private int progressValue;
        #endregion
        #region CTOR
        public MailDashboardViewModel(IRepository<Mail> mailRepository)
        {
            this.mailRepository = mailRepository;

            var demoMails = mailRepository.GetAll();
            Mails = CollectionViewSource.GetDefaultView(demoMails);
        }
        #endregion
        #region Properties

        public ICollectionView Mails { get; set; }
        
        public Mail SelectedMail
        {
            get { return selectedMail; }
            set { selectedMail = value; RaisePropertyChanged(nameof(SelectedMail)); }
        }

        public string Filter
        {
            get { return filter; }
            set { filter = value; 
                RaisePropertyChanged(nameof(Filter));
                ApplyFilter();
            }
        }
        public bool IsSortedAscending
        {
            get { return isSortedAscending; }
            set
            {
                isSortedAscending = value;
                RaisePropertyChanged(nameof(IsSortedAscending));
                RaisePropertyChanged(nameof(IsSortedDescending));
                ApplySort();

            }
        }

        public bool IsSortedDescending
        {
            get { return !isSortedAscending; }
            set { IsSortedAscending = !value; }
        }

      

        #endregion
        #region Private Methods
        private void ApplyFilter()
        {
            Mails.Filter = o =>
            {
                var mail = o as Mail;
                return mail.User.Username.Contains(Filter) || mail.Date.ToString().Contains(Filter);
            };
        }
        public void ApplySort()
        {
           
            var sortDescription = IsSortedAscending ? new SortDescription(nameof(Mail.Date), ListSortDirection.Ascending) :
                new SortDescription(nameof(Mail.Date), ListSortDirection.Descending);

            Mails.SortDescriptions.Clear();
            Mails.SortDescriptions.Add(sortDescription);
        }



        #endregion
    }
}
