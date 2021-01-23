    while (true)
    {
        try
        {
            // try and connect to whatever you're waiting for on your instance(s)
            ConnectToInstance("instance IP address goes here");
            return;
        }
        catch (Exception e)
        {
            Console.WriteLine("Still waiting to connect: " + e)        
            Thread.Sleep(5000);
        }
    }
