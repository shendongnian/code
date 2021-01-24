    class ViewModel : INotifyPropertyChanged
    {
        private int _maxValue;
        private int _currentValue;
        private int? _taskThreadId;
        private bool _taskRunning;
        public ICommand StartInForeground { get; }
        public ICommand StartInBackground { get; }
        public int MaxValue
        {
            get { return _maxValue; }
            set { _UpdateField(ref _maxValue, value); }
        }
        public int CurrentValue
        {
            get { return _currentValue; }
            set { _UpdateField(ref _currentValue, value); }
        }
        public int? TaskThreadId
        {
            get { return _taskThreadId; }
            set { _UpdateField(ref _taskThreadId, value); }
        }
        public bool TaskRunning
        {
            get { return _taskRunning; }
            set { _UpdateField(ref _taskRunning, value, _OnTaskRunningChanged); }
        }
        public int UiThreadId { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ViewModel()
        {
            UiThreadId = Thread.CurrentThread.ManagedThreadId;
            StartInForeground = new DelegateCommand(_StartInForeground, () => !TaskRunning);
            StartInBackground = new DelegateCommand(_StartInBackground, () => !TaskRunning);
        }
        // NOTE: generally, "async void" methods should be avoided. They are legitimate
        // for event handlers and, as in this case, invoked commands and for illustration
        // purposes.
        private async void _StartInForeground()
        {
            TaskRunning = true;
            await _CountUp();
            TaskRunning = false;
        }
        private async void _StartInBackground()
        {
            TaskRunning = true;
            await Task.Run(_CountUp);
            TaskRunning = false;
        }
        private async Task _CountUp()
        {
            TaskThreadId = Thread.CurrentThread.ManagedThreadId;
            CurrentValue = 0;
            while (CurrentValue < MaxValue)
            {
                await Task.Delay(100);
                CurrentValue++;
            }
            TaskThreadId = null;
        }
        private void _OnTaskRunningChanged(bool obj)
        {
            // NOTE: this method is _not_ automatically marshalled to the UI thread
            // by WPF, because its execution doesn't go through a binding. So it's
            // important that the TaskRunning property is only modified in the UI
            // thread. An alternative implementation would do additional work to
            // capture the current SynchronizatioContext when this ViewModel object
            // is created and use it to post the method calls below.
            ((DelegateCommand)StartInForeground).RaiseCanExecuteChanged();
            ((DelegateCommand)StartInBackground).RaiseCanExecuteChanged();
        }
        protected void _UpdateField<T>(ref T field, T newValue,
            Action<T> onChangedCallback = null,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }
            T oldValue = field;
            field = newValue;
            onChangedCallback?.Invoke(oldValue);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
