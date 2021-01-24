    public long Done
    {
        get { return done; }
        set
        {
            done = value;
            OnPropertyChanged("Done"); //<--
        }
    }
