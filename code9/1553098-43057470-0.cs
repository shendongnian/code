    public bool IsValid
    {
        get { return isValid; }
        set
        {
            if (isValid == value)
            {
                return;
            }
            isValid = value;
            OnPropertyChanged();
        }
    }
