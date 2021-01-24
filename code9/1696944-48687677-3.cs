    private DateTimeOffset _dpDateTime = DateTime.Now;
    
    public DateTimeOffset dpDateTime
    {
       get { return _dpDateTime; }
       set 
       {  
           _dpDateTime = value;
           NotifyPropertyChanged();
       }
    }
