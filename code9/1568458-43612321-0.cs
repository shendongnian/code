    Ping pingSender = new Ping();
    IPAddress address = System.Net.IPAddress.Parse("8.8.8.8");
    PingReply reply = pingSender.Send(address);
    
    if (reply.Status == IPStatus.Success)
    {
        Console.WriteLine("OK");
    }
    else
    {
        Console.WriteLine("NOT OK");
    }
