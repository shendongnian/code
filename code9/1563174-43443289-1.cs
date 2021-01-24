    // bool createNotDeleted = true;
    _commandService.CreateCommand("create").Parameter("message", ParameterType.Multiple).Do(async e =>
    {    
    	if (createNotDeleted) 
    	{
    		var message = e.Args.Skip(1).Aggregate("", (current, t) => current + (t + " "));;
    
    	    _commandService.CreateCommand("hello").Do(async cc =>
    	    {
    	        await e.User.SendMessage(customCommand.Message);
    	    });
    	}
    	else
    	{
    		// error handling
    	}    
        
    });
