    using System.Net.NetworkInformation; //required for ping
    
    Console.Write("Address to ping: ");
    string nameOrAddress = Console.ReadLine();
    bool pingable = false;
    Ping pinger = new Ping();
    try
    {
        PingReply reply = pinger.Send(nameOrAddress);
        pingable = reply.Status == IPStatus.Success;
        if(pingable == true) 
        {
        	Console.WriteLine("Connected successfully");
        }
        else if(pingable == false) 
        {
        	Console.WriteLine("Unable to connect");
        }
        else 
        {
        	Console.WriteLine("Unknown Error. Try again. Maybe an incorrect address");
        }
    }
    catch (PingException)
    {
        Console.WriteLine("Unknown Error. Try again. Maybe an incorrect address");
    }
