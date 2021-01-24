    public bool timerInProgress = false; 
    public TimeSpan ts = new TimeSpan();
    public Stopwatch = new Stopwatch();
       
    public void triggerTimer()
    {
       if (timerInProgress)
       { 
         stopWatch.Stop();
         ts = stopWatch.Elapsed;
       }
       else stopWatch.Start();
      timerInProgress = !timerInProgress;
    }
    private void button1_Click(object sender, System.EventArgs e)
    {
      triggerTimer();
      //your code
    }
    }
    private void button2_Click(object sender, System.EventArgs e)
    {
       triggerTimer();
       //your code
    }
