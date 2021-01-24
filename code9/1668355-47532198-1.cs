    private bool _ackStatus;
    public bool AckStatus
    {
        get
        {
            if (_model.AcknStatus == 0)
                return false;
            else
                return true;
        }
        set
        {
            _ackStatus = value;
            _model.AcknStatus = value ? 1 : 0;
            RaisePropertyChanged(() => AckStatus);
        }
    }
