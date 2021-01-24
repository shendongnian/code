    // True asynchronous calls
    public async Task<string> FLogin(int waitTime)
    {
      await Task.Delay(waitTime);
      return HttpContext.Current.Session.SessionID + "_" + Thread.CurrentThread.ManagedThreadId; 
    }
    public async Task<string> BlendDualCall()
    {
      var cTask = YLogin(1000);
      var fTask = FLogin(2000);
      ...
    }
