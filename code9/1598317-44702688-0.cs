    public bool UseRequiered 
    { 
           get { return _UseRequried; }
           set { 
                  _UseRequried = value; 
                  _IsRequired  =  { Whatever logic is deemed };
                  _IsEnabled   =  { Whatever logic is deemed };
                   
                   OnPropertyChanged("IsRequired");
                   OnPropertyChanged("IsEnabled");
                   OnPropertyChanged(); 
               }          
    }
    public bool IsRequiered 
    { 
           get { return _IsRequiered; }
           set { _IsRequiered = value } // Doesn't need OnPropertyChanged, we do it elsewhere.
    }
    public bool IsEnabled 
    { 
           get { return _IsEnabled; }
           set { _IsEnabled = value } // Doesn't need OnPropertyChanged, we do it elsewhere.
    }
