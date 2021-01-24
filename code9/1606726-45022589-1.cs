    public Startup()
    {
        var container = new DiContainer(); // I know this is the wrong name; I'm not familiar with the built in container naming and functionality.
        container.Register<IMessage>();
        container.Register<IMessagePart>();
        container.Register<IProject>();
        
        // Register other stuff here
    }
