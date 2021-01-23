    while (splash.IsAlive)
    {
        Thread.Sleep(1000);
    }
    
    if (splashCont)
    {
        splash.Abort();
        this.Close();
    }
