    private bool _ackStatus;
    public bool AckStatus
    {
        get
        {
            return _ackStatus;
        }
        set
        {
            _ackStatus = value;
            RaisePropertyChanged(() => AckStatus);
        }
    }
