    public string FLogin(int waitTime, string sessionId)
    {
      Thread.Sleep(waitTime);
      return sessionID + "_" + Thread.CurrentThread.ManagedThreadId; 
    }
    public string BlendDualCall()
    {
      var sessionId = HttpContext.Current.Session.SessionID.ToString();
      var cTask = Task.Run(() => YLogin(1000, sessionId));
      var fTask = Task.Run(() => FLogin(2000, sessionId));
      ...
    }
