    private DateTime _calDate;
    public DateTime CalDate
    {
         get { return _calDate; }
         set
         {
             _calDate = value;
             NotifyPropertyChanged();
         }
     }
