    public bool UseRequiered 
    { 
        get { return _UseRequried; }
        set { _UseRequried = value; DetermineStyle(); }// PropertyChanged in DetermineStyle()
          
    }
    public bool IsRequiered
    {
        get { return _IsRequiered; }
        set { _IsRequiered = value; DetermineStyle();} // PropertyChanged in DetermineStyle()
    }
    public bool IsEnabled 
    { 
       get { return _IsEnabled; }
       set { _IsEnabled = value; DetermineStyle(); } // Prop change in DetermineStyle
    }
    private void DetermineStyle()
    {
         _UseRequiered = { Whatever logic is deemed };
         _IsRequired  =  { Whatever logic is deemed };
         _IsEnabled   =  { Whatever logic is deemed };
                   
         OnPropertyChanged("IsRequired");
         OnPropertyChanged("IsEnabled");
         OnPropertyChanged("UseRequiered"); 
    }
