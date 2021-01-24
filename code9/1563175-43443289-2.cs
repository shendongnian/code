    _commandService.CreateCommand("delete").Parameter("message", ParameterType.Multiple).Do(async e =>
    {    
        if (createNotDeleted)
        {
        	createNotDeleted = false
        	// return something indicating command is deleted
        }
        else
        {
        	// error handling
        }
    });
