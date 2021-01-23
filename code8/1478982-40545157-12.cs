    public string Title
    {
        get
        {
            return myClassBase?.Title;
        }
        set
        {
            if (myClassBase != null)
                    myClassBase.Title = value;
            RaisePropertyChanged();
        }
    }
