    public void start()
    {
        for (int i = 0; i < 50; i++)
        {
            Task.Run(() => RunScanTcp());
        }
    }
    public void RunScanTcp()
    {
        while (abort != true)
        {
                port = port + 1;
                Log.Info("PORT SCANNER", port.ToString());
        }
    }
