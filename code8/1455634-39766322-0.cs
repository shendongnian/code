    public Task DatabaseActionAsync(string argument)
	{
        return Task.Run(() => 
            DatabaseAction(argument));
		);
	}
