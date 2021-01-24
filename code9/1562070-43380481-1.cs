    public class MainWindowViewModel : BindableBase
    {
        CancellationTokenSource _cts = new CancellationTokenSource();
        public MainWindowViewModel()
        {
            Time = new TimeSpan();
        }
        #region Properties
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }
        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { SetProperty(ref _isRunning, value); }
        }
        #endregion // Properties
        #region Commands
        public DelegateCommand StartTimerCommand => new DelegateCommand(StartTimer);
        private async void StartTimer()
        {
            await RepeatActionEvery(() => UpdateTimer(), TimeSpan.FromSeconds(1), _cts.Token);
        }
        public DelegateCommand StopTimerCommand => new DelegateCommand(StopTimer);
        private void StopTimer()
        {
            _cts.Cancel();
            Time = new TimeSpan();
            _cts = new CancellationTokenSource();
        }
        #endregion // Commands
        #region Private Methods
        private void UpdateTimer()
        {
            var timeIncrement = TimeSpan.FromSeconds(1);
            Time = Time.Add(timeIncrement);
        }
        #endregion // Private Methods
        #region Helpers
        public static async Task RepeatActionEvery(Action action, TimeSpan interval, CancellationToken cancellationToken)
        {
            while (true)
            {
                action();
                Task task = Task.Delay(interval, cancellationToken);
                try { await task; }
                catch (TaskCanceledException) { return; }
            }
        }
        #endregion // Helpers
    }
