    public async Task NewStuffAsync()
    {
      // Use await and have fun with the new stuff.
      await ...
    }
    
    public Task MyOldTaskParallelLibraryCode()
    {
      // Note that this is not an async method, so we can't use await in here.
      ...
    }
    
    public async Task ComposeAsync()
    {
      // We can await Tasks, regardless of where they come from.
      await NewStuffAsync();
      await MyOldTaskParallelLibraryCode();
    }
