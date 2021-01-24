    if (timerName != null)
    {
      timerName.Stop();
      timerName.Dispose();
      timerName = new Timer();
    }
    timerName.Tick += new EventHandler(timerName_Tick);
