    public void Log()
    {
      var stackTrace = new System.Diagnostics.StackTrace(1); // skip one frame as this is the Log function frame
      var name = stackTrace.GetFrame(0).GetMethod().Name;
    }
