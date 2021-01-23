    public void delayStartService()
    {
        Task.Delay(1000).ContinueWith(t => startService());
    }
    
    public MySvc()
    {
        delayStartService();
    }
