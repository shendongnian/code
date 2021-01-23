    private readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);
    //Function that is attached to each pages "LayoutUpdated" call.
    private async void AnyPageLayoutUpdated(object sender, object e)
    {
      await _mutex.WaitAsync();
      try
      {
        LCDDriver.ILI9488.PaintScreen(sender);
      }
      finally
      {
        _mutex.Release();
      }
    }
