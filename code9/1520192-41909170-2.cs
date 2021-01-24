    private bool _IsEnabled;
    public bool IsEnabled 
     { get 
          {
             return _IsEnabled ; 
          }
         set
          {
              _IsEnabled  = value;
               RaisePropertyChanged("IsEnabled ");
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
 
