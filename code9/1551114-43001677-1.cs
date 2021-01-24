    CustomClient customClient = new CustomClient();
    CustomServer customServer = new CustomServer();
    
    Exception serverStartException = null;
    
    System.Threading.Tasks.Task.Factory.StartNew(() =>
    {
        try
        {
            customServer.Start();
        }
        catch (Exception e)
        {
            serverStartException = e;
        }
    }
    
    int maxTries = 5;
    int currentTry = 0;
    
    while (!customServer.IsStarted && currentTry < maxTries && serverStartException == null)
    {
        System.Threading.Thread.Sleep(1000);
        currentTry++;
    }
    if (serverStartException != null)
    {
        throw new Exception("The server couldn't start", serverStartException );
    }
    else if (!customServer.IsStarted)
    {
        throw new Exception("The server couldn't start for unknown reason");
    }
    
    customClient.Connect();
    if (customClient.ServiceProxy.IsServiceInitiated())
    {
        MessageBox.Show("Server initiated");
    }
