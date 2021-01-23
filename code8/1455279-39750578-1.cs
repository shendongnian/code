    private DelegateCommand _runCommand;
    public ICommand RunCommand {
        get {
            if (_runCommand == null)
            {
                _runCommand = new DelegateCommand(RunCommandExecute, ExecuteCanExecute);
            }
            return _runCommand;
        }
    }
    protected void RunCommandExecute(Object parameter)
    {
        //  Do stuff
    }
    protected bool RunCommandCanExecute(Object parameter)
    {
        //  Return true if command can be executed
        return parameter != null;
    }
