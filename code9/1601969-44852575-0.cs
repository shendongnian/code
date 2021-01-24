    private void Timer_Callback(object state)
    {
        if (this.InvokeRequired)
        {
            BeginInvoke(new TimerCallbackDelegate(Timer_Callback), new object[]{ 
            state });
        }
        else
        {     
          this._timer.Change(System.Threading.Timeout.Infinite,
          System.Threading.Timeout.I
      nfinite);
            this._timer.Dispose();
            this.Close();
        }       
    }
