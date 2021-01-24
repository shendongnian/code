    private System.Threading.Timer timer;
    private void SetUpTimer()
    {
        
         this.timer = new System.Threading.Timer(x =>
         {
             this.OnTimeEvent();
         } , null, 0, "Interval to run your thread.");
    }
    
    private void OnTimeEvent()
    {
       // Do your other thing Here
    }
