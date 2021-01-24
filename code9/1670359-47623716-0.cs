    using (ServiceHost host = new ServiceHost(typeof(Exec)))
    {
        host.Open();
        Console.WriteLine("exec service started at {0}", host.BaseAddresses[0]);
        Console.WriteLine("Press any key to end...");
        Console.ReadLine();
    }
