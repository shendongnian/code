    private Object thisLock = new Object();
        
    lock (thisLock)
       {
          if (!MvcApplication.GlobalMemoryLeads.ContainsKey(EncodedLead))
          {
              try
              {
                 MvcApplication.GlobalMemoryLeads.Add(EncodedLead, false);
                 ...
