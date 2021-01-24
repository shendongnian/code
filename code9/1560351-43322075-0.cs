    public bool CanEnableButton
    {
        get
        {
            return _canEnableBtn;
        }
        set
        {
           _canEnableBtn = value;
           NotifyPropertyChanged("CanEnableButton");
        }
    }
    public bool CanEnableRadio
    {
        get 
        {              
            return _canEnableRadio;
        }
        set
        {
            _canEnableRadio = value;
            NotifyPropertyChanged("CanEnableRadio");
        }
    }
    public bool CanEnableAccept
    {
        get
        {
            return _canEnableAcpt;
        }
        set
        {
             _canEnableAcpt = value;
             NotifyPropertyChanged("CanEnableAccept");
        }        
