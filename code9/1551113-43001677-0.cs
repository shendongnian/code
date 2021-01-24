    CustomClient customClient = new CustomClient();
    CustomServer customServer = new CustomServer();
    
    System.Threading.Tasks.Task.Factory.StartNew(() =>
    {
        customServer.Start();
    }
    
    while (!Program.mainServer.IsStarted)
    {
        System.Threading.Thread.Sleep(1000);
    }
    customClient.Connect();
    if (customClient.ServiceProxy.IsServiceInitiated()) // FREEZE HERE !!
    {
        MessageBox.Show("Server initiated");
    }
