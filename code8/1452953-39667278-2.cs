    private TaskCompletionSource<bool> _tcs;
    public async Task TryConnect()
    {
       if (/* no connection exists */)
       {
         if (_tcs == null)
         {
           this.timer = new Timer(_ => tryConnect(),null,-1,-1);
           this.timer.Change(0,-1); 
           _tcs = new TaskCompletionSource<bool>();
         }
         await _tcs.Task;
       }
    }
    
    private void tryConnect()
    {
       if (/*connection failed*/)
         this.timer.Change(interval,-1);
       else
       {
         _tcs.SetResult(true);
         _tcs = null;
         this.timer = null;
       }
    }
