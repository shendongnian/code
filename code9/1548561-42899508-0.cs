     ServiceHost sHost = new ServiceHost(typeof(Class1));
        sHost.Open();
        Console.WriteLine("Service Started....");
       //Keeps Servece Open
        Console.ReadLine();
     sHost.Close()
