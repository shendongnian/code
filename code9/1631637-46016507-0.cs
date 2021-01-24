    public async Task InstallCommand()
    {
        client.MessageReceived += HandleCommand;
        await commands.AddModuleAsync(Assembly.GetEntryAssembly);
    } 
 
