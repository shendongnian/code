    public async Task MyAsyncMethod()
    {
      // Do your stuff that takes a long time
    }
    
    public async Task CallMyAsyncMethod()
    {
      // We can await Tasks, regardless of where they come from.
      await MyAsyncMethod();
    }
