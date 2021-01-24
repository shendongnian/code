    public bool IsWorking
    {
        get { return isWorking; }
        set
        {
           isWorking = value;
           Notify(nameof(IsWorking));
           MyRelayCommand.UpdateCanExecute();
        }
    }
