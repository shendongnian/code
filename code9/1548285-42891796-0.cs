    class RLFDatabaseTableViewModel : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
      
      private void RaisePropertyChanged(string property)
      {
        if (PropertyChanged != null) {
          PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
      }
    
      // the rest of RLFDatabaseTableViewModel implementation ...
    }
