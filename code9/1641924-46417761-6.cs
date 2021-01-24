    class JobTimer : NotifyPropertyChangedBase
    {
        private DateTime _started; // When it was most recently started
        private TimeSpan _offset; // The saved value to offset the currently running timer
        Timer _swTimer; // The actual tick that updates the screen
        private readonly DelegateCommand _startCommand;
        private readonly DelegateCommand _stopCommand;
        public ICommand StartCommand => _startCommand;
        public ICommand StopCommand => _stopCommand;
        public JobTimer() : this(TimeSpan.Zero)
        { }
        public JobTimer(TimeSpan offset)
        {
            _offset = offset;
            _startCommand = new DelegateCommand(Start, () => !IsRunning);
            _stopCommand = new DelegateCommand(Stop, () => IsRunning);
        }
        private TimeSpan _elapsedTime;
        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            set { _UpdateField(ref _elapsedTime, value); }
        }
        public void Start()
        {
            _started = DateTime.UtcNow;
            _swTimer = new Timer(TimerChanged, null, 0, 1000);
            IsRunning = true;
        }
        public void Stop()
        {
            if (_swTimer != null)
            {
                _swTimer.Dispose();
                _swTimer = null;
            }
            _offset += DateTime.UtcNow - _started;
            IsRunning = false;
        }
        private TimeSpan GetElapsed()
        {
            return IsRunning ? DateTime.UtcNow - _started + _offset : _offset;
        }
        // Updates the UI
        private void TimerChanged(object state)
        {
            ElapsedTime = GetElapsed();
        }
        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _UpdateField(ref _isRunning, value, _OnIsRunningChanged); }
        }
        private void _OnIsRunningChanged(bool obj)
        {
            _startCommand.RaiseCanExecuteChanged();
            _stopCommand.RaiseCanExecuteChanged();
        }
    }
