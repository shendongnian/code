    public bool Autoreset
    {
        get { return _timer.Autoreset; }
        set
        {
            _timer.Autoreset = value;
            InvokePropertyChanged(new PropertyChangedEventArgs(nameof(TimerEnabled));
            InvokePropertyChanged(new PropertyChangedEventArgs(nameof(Autoreset));
        }
    }
