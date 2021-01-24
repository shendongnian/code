    private Nullable<System.DateTime> _dateTimeFrom;
    public Nullable<System.DateTime> DateTimeFrom
    {
        get { return _dateTimeFrom; }
        set
        {
            _dateTimeFrom = value;
            NotifyPropertyChanged("DateTimeFrom");
        }
    }
    private Nullable<System.DateTime> _dateTimeTo;
    public Nullable<System.DateTime> DateTimeTo
    {
        get { return _dateTimeTo; }
        set
        {
            _dateTimeTo = value;
            NotifyPropertyChanged("DateTimeTo");
        }
    }
