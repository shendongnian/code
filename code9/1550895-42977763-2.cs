    public TimeSpan ts = new TimeSpan();
    public Stopwatch = new Stopwatch();
       
    public void triggerTimer()
    {
       if (StopWatch.IsRunning)
       { 
         stopWatch.Stop();
         ts = stopWatch.Elapsed;
       }
       else stopWatch.Start();
     
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
