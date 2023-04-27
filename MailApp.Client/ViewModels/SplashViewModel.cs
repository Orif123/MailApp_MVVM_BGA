using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace MailApp.Client.ViewModels
{
    public class SplashViewModel : ViewModelBase
    {
        #region Fields
        public BackgroundWorker _worker;
        private int progressCounter = 0;
        private Visibility barVisibillity = Visibility.Visible;
        #endregion
        #region CTOR
        public SplashViewModel()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += DoWork;
            _worker.ProgressChanged += ProgressChanged;
            _worker.RunWorkerCompleted += RunWorkerCompleted;
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            Start();
        }
        #endregion
        #region Delegate
        public delegate void SwitchView();
        #endregion
        #region Properties
        public static SwitchView OnSwitchView { get; set; }
        public int ProgressCounter
        {
            get { return progressCounter; }
            set
            {
                progressCounter = value;
                RaisePropertyChanged(nameof(ProgressCounter));
            }
        }
        public Visibility BarVisibillity
        {
            get { return barVisibillity; }
            set { barVisibillity = value; RaisePropertyChanged(nameof(BarVisibillity)); }
        }
        #endregion
        #region BackgroundWorker
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (_worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                Thread.Sleep(50);
                _worker.ReportProgress(i);
            }

            e.Result = null;
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressCounter = e.ProgressPercentage;
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                BarVisibillity = Visibility.Collapsed;
                if (OnSwitchView != null)
                {
                    OnSwitchView();
                }
            }
        }
        #endregion
        #region Private Methods
        private void Start()
        {
            _worker.RunWorkerAsync();
        }
        #endregion
    }
}