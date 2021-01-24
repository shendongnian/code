    public bool BackBool
    {
        get { return isBackEnabled; }
        set
        {
            isBackEnabled = value;
            this.RaisePropertyChangedEvent("BackBool");
        }
    }
