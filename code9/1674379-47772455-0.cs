    public async Task SaveAsync()
    {
       // .. save to disk ..
       
       await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
       {
          // update UI here
       }
      
       // Save Complete!
    }
