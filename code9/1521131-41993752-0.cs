    foreach(Network network in networks)
    {
        //Name property corresponds to the name I originally asked about
        Console.WriteLine("[" + network.Name + "]");
        Console.WriteLine("\t[NetworkConnections]");
        foreach(NetworkConnection conn in network.Connections)
        {
            //Print network interface's GUID
            Console.WriteLine("\t\t" + conn.AdapterId.ToString());
        }
    }
