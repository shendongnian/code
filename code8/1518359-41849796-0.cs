    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                    _loadCommand = new RelayCommand(OnLoad, CanLoad);
                return _loadCommand;
            }
        }
        private void OnLoad()
        {
            IsEnabled = false;
            _canLoad = false;
            _loadCommand.RaiseCanExecuteChanged();
            Task.Factory.StartNew(()=> { System.Threading.Thread.Sleep(5000); })  //simulate som long-running operation that runs on a background thread...
                .ContinueWith(task =>
                {
                    //reset the properties back on the UI thread once the task has finished
                    IsEnabled = true;
                    _canLoad = true;
                }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private bool _canLoad = true;
        private bool CanLoad()
        {
            return _canLoad;
        }
        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; RaisePropertyChanged(); }
        }
    }
