    private System.Threading.Timer _syncTimer;
    private bool _isRunning;
        
    public Constructor(){
        _syncTimer=new System.Threading.Timer(TimerCallback);
    }
        
    public void StartSyncTimer(){
        _syncTimer.Change(0, 0);
    }
            
    private async Task SyncUsers(){
            //
    }
    private void TimerCallback(object userState){
        _isRunning = true;
        var task = SyncUsers();
        task.ContinueWith(t=>{
            _isRunning = false;
            _syncTimer.Change(TimeSpan.FromSeconds(refreshInterval), TimeSpan.FromSeconds(0))
        })
    }
