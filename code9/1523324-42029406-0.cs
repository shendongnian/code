    public ICommand ReloadCommand
    {
        return new MvxAsyncCommand(DoAsyncStuff);
    }
    
    private Task DoAsyncStuff(MyType type)
    {
    
    }
