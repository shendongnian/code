    Class Question : INotifyPropertyChanged, IQuestion
    {
      public ICommand ButtonClickCommand { get; set;}
    
      public Question()
      {
        //Bind ButtonClickCommand to Event Handler/ A Method
        ButtonClickCommand = new DelegateCommand(EventHandlerName);
      }
      public void EventHandlerName()
      {
      }
    }
