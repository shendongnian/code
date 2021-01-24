    public string StartTimeText
    {
        get
        {
            return starttimetext;
        }
        set
        {
            if (starttimetext != value)
            {
                starttimetext = value;
                this.OnPropertyChanged();
            }
        }
    }
