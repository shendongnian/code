    private ObservableImmutableList<Period> periodCollection;
    public ObservableImmutableList<Period> PeriodCollection 
    { 
       get { return periodCollection; } 
       set { periodCollection = value; NotifyPropertyChanged(); } 
    }
    
    private Period selectedDuration;
    public Period SelectedDuration 
    { 
      get { return selectedDuration; } 
      set { selectedDuration = value; NotifyPropertyChanged(); } 
    }
    private int _providedNumber;
    public int ProvidedNumber
    { 
      get { return _providedNumber; } 
      set { _providedNumber= value; NotifyPropertyChanged(); } 
    }
    
    private void GetPeriod()
    {
        PeriodCollection =  PeriodManager.GetPeriodCollection();
        //here I need to write logic to merge from both values [ txtBox+combox]
    }
