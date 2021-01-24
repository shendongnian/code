    public string Minutes
    {
        get => this.minutes; 
        set
        {
            if (this.minutes != value)
            {
                this.minutes = value;
                OnPropertyChanged();
            }
        }
    }
