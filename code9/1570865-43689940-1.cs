    MostRecentlyStartedProcess(Process.GetProcessesByName("MyProcess"));
    public Process MostRecentlyStartedProcess(Process[] procceses)
    {
      Process result = null;
      foreach (Process process in procceses)
      {
        if (result == null)
        {
          result = process;
        }
        else
        {
          if (process.StartTime < result.StartTime)
          {
            result = process;
          }
        }
      }
      return result;
    }
