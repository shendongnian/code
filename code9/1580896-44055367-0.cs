    public void DownloadFile(Uri uri, string desintaion)
    {
      using(var wc = new WebClient())
      {
        wc.DownloadProgressChanged += HandleDownloadProgress;
        wc.DownloadFileCOmpleted += HandleDownloadComplete;
     
        var syncObj = new Object();
        lock(syncObject)
        {
           wc.DownloadFileAsync(sourceUri, destination, syncObject);
           //This would block the thread until download completes
           Monitor.Wait(syncObject);
        }
      }
      
      //Do more stuff after download was complete
    }
     
    public void HandleDownloadComplete(object sender, AsyncCompletedEventArgs args)
    {
       lock(e.UserState)
       {  
          //releases blocked thread
          Monitor.Pulse(e.UserState);
       }
    }
     
     
    public void HandleDownloadProgress(object sender, DownloadProgressChangedEventArgs args)
    {
      //Process progress updates here
    }
