          private Uri _frameSource = new Uri("http://www.google.com", UriKind.Absolute);
          public Uri FrameSource
          {
             get { return _frameSource;}
    
             set
             {
                _frameSource = value;
                OnPropertyChanged("FrameSource");
             }
          }
    
          public ICommand GoToCommand
          {
             get
             {
                return new DelegateCommand(ExecuteGoTo);
             }
          }
    
          private void ExecuteGoTo()
          {
             FrameSource = new Uri("http://www.msdn.com", UriKind.Absolute);
          }
        
    
