    public ObservableCollection<Communication> TestEntries
    {
       get
       {
          return _testEntries;                  
       }
       set
       {
          _testEntries = value;
          //OnPropertyChanged(); <-- of no use
        }
     }
