    void SomeMethodInMyWpfApp()
    {
    
        ServiceController sc = new ServiceController("MissPiggyService");
        if (sc.Status != ServiceControllerStatus.Running && 
            sc.Status != ServiceControllerStatus.StartPending)
        { 
            sc.Start();
        }
    }
