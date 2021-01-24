    private System.Threading.Timer _timer;
    
    private void go()
    {
        _timer = new Timer(_ => Timer_Tick(), null, 0, 1000 * 10); //every 10 seconds
    }
    
    private void Timer_Tick()
    {
      //this is not the main UI thread. Must invoke if you want to interact with the UI
    }
