    public ICommand ChangeLangCommand
    {
        get
        {
            return new DelegateCommand(this.ChangeLangClick);
        }
    }
