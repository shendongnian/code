    public void StartCommand<T>() where T: ICommand,new()
    {
        T command = new T();
        command.Execute(command);
    }
