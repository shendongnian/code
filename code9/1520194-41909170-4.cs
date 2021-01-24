    private bool _IsEnable;
    public bool IsEnable 
     { get 
          {
             return _IsEnable ; 
          }
         set
          {
              _IsEnable  = value;
               RaisePropertyChanged("IsEnable ");
          }
      }
    internal void RaisePropertyChanged(string prop)
     {
         if (PropertyChanged != null)
          { 
            PropertyChanged(this, new PropertyChangedEventArgs(prop)); 
          }
     }
    public event PropertyChangedEventHandler PropertyChanged;
 
