    public Task TryConnect()
    {
       if (/* no connection exists */)
       {
         if (_tcs == null)
         {
           this.timer = new Timer(_ => tryConnect(),null,-1,-1);
           this.timer.Change(0,-1); 
           _tcs = new TaskCompletionSource<bool>();
         }
         return _tcs.Task;
       }
       return Task.CompletedTask;
    }
