    public MyViewModel(MyModel myModel, IMyService myService)
     {
        ...
        this.PropertyChanged += (sender, args) => 
                                {
                                    if (_canGetDirty)
                                        _myService?.AskForSaving();
                                };
     }
