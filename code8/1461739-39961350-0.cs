    public System.DateTime TimeUTC
    {
        get;
        set;
    }
    [NotMapped]
    public System.DateTime LocalTime
    {
        get
        {
            return this.TimeUTC.ToLocalTime();
        }
        set
        {
            this.TimeUTC = value.ToUniversalTime();
        }
    }
