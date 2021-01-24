    protected void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      this.timer.Stop(); //stop the timer 
      this.proccessQue(); //process the queue
      this.timer.Start(); //restart the timer
    }
