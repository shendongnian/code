    private System.Threading.Timer timer;
    private void SetUpTimer()
    {
        
         this.timer = new System.Threading.Timer(x =>
         {
             this.OnTimeEvent();
         }, null, "Set the interval for your thread", Timeout.InfiniteTimeSpan);
    }
    
    private void OnTimeEvent()
    {
       // Do your other thing Here
    }
