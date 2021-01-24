    public DateTime MDate
    {
       get { return _mDate; }
       set 
       { 
           _mDate = value; 
           OnPropertyChanged("MDate"); 
           OnPropertyChanged("Efficiency"); 
       }
    }
