    class YourViewModel : ViewModelBase
    {
      public string ActiveView
      {
        get { return _ApplicationMessage; }
        //Note that this setter performs notification
        set { Set(ref _ApplicationMessage, value); }
      }
      private RelayCommand<string> _SetViewCommand = null;
      public RelayCommand<string> SetViewCommand
      {
        get
        {
          if (_SetViewCommand == null)
          {
            _SetViewCommand = new RelayCommand<string>((v) =>
            {
              ActiveView = v;
            }
          }
          
          return _SetViewCommand;
        }
      }
    }
