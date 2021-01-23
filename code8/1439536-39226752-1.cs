    ICommand _changeLangCommand;
    public ICommand ChangeLangCommand
    {
        get
        {
            return _changeLangCommand;
        }
    }
    // in constructor
    _changeLangCommand = new DelegateCommand(this.ChangeLangClick);
