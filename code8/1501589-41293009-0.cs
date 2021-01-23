            <Button Name="BtnReload" Command="{Binding DoWorkCommand}" Width="75" Height="25"/>
            <ProgressBar Minimum="{Binding Path=Minimum}" Maximum="100" IsIndeterminate="{Binding Path=IsIndeterminate}" Height="20"/>
 
       public class MainViewModel : ViewModelBase {
        private RelayCommand _doWorkCommand;
        private bool _isIndeterminate;
        private int _minimum;
        private Dispatcher _threadDispatcher;
        public int Minimum {
            get { return _minimum; }
            set {
                _minimum = value;
                RaisePropertyChanged(nameof(Minimum));
            }
        }
        public bool IsIndeterminate {
            get { return _isIndeterminate; }
            set {
                _isIndeterminate = value;
                RaisePropertyChanged(nameof(IsIndeterminate));
            }
        }
        public MainViewModel(IDataService dataService) {
        }
        public void StartImportThread() {
            //  ButtonsEnabled = false;
            var th = new Thread(new ThreadStart(StartImport));
            th.IsBackground = true;
            th.Start();
        }
        public void StartImport() {
            _threadDispatcher = Dispatcher.CurrentDispatcher;
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_Complete;
            worker.RunWorkerAsync();
            // Doing Import Stuff
            worker.CancelAsync(); // Import finished
            //   ButtonsEnabled = true;
            
        }
        void worker_DoWork(object sender, DoWorkEventArgs e) {
            Minimum = 0;
            IsIndeterminate = true;
            //for (int i = 0; i < 30; i++) {
            //    Thread.Sleep(100);
            //}     
        }
        void worker_Complete(object sender, RunWorkerCompletedEventArgs e) {
            IsIndeterminate = false;
            Minimum = 100;
        }
        public RelayCommand DoWorkCommand => _doWorkCommand ??
            (_doWorkCommand = new RelayCommand(() => StartImportThread()));
    }
