    // mvc action
    new MyCommand
    {
        Payload = "foo"
        CurrentUser = User // User is a Controller.User property
    };
	
    // signalr hub
    new MyCommand
    {
        Payload = "bar"
        CurrentUser = Context.User
    };
	
