    private bool isButtonEnable;
    public bool IsButtonEnable
    {
        get
        {
            return isButtonEnable;
        }
        set
        {
            isButtonEnable = value;
            OnPropertyChanged("IsButtonEnable");
        }
    }
