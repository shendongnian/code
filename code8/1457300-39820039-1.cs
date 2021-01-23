    class MyItemClass : INotifyPropertyChanged
    {
      public string Text {get;set;}
       private ICommand _testCommand;
        public ICommand TestCommand
        {
            get
            {
                return _testCommand;
            }
            set
            {
                if (_testCommand != value)
                {
                    _testCommand = value;
                    OnPropertyChanged();
                }
            }
        }
  
       public event PropertyChangedEventHandler PropertyChanged;
       protected virtual void OnPropertyChanged([CallerMemberName]string caller="")
       {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
      }
