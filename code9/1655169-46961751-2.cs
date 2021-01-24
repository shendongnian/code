    public void Process(MyAction action)
    {
        if (action is RenameAction)
        {
            RenameAction ra = action as RenameAction;
            ...
        }
        else if (action is StartAction)
        {
            StartAction sa = action as StartAction;
            ...
        }
