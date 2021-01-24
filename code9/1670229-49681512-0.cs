    public async Task DownloadAndInstall(...)
    {
      ...
      
      // Download
      try
       {
          await Download(...)
       }
       catch (Exception ex)
       {
           throw new DownloadException("Something bad happened");
       }
       ...
    }
    public async Task Download(...)
    {
       ...
       // try some web activity
       try
       {
          ...
       }
       catch (System.Net.WebException ex)
       {
          throw new Exception("Uncaught exception", ex);
       }
       ...
    }
