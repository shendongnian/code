    public async void Execute(object parameter)
    {
        mIsExecuting = true;
        myCommand.RaiseCanExecuteChanged ( );
        await ExecuteAsync(parameter);
        mIsExecuting = false;
        myCommand.RaiseCanExecuteChanged ( );
    }
