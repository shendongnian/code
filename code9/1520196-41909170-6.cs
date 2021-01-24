    private bool _Visibility;
    public bool Visibility
     { get 
          {
             return _Visibility ; 
          }
         set
          {
              _Visibility  = value;
               RaisePropertyChanged("Visibility");
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
 
