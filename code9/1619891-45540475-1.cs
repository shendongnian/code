    public static void RemotePing ()
    {
        // Ping's the local machine.
        Ping pingSender = new Ping ();
        IPAddress address = IPAddress.Parse("192.168.1.1"); //or IP address you'd like
        PingReply reply = pingSender.Send (address);
    
        if (reply.Status == IPStatus.Success)
        {
            Console.WriteLine ("Address: {0}", reply.Address.ToString ());
            Console.WriteLine ("RoundTrip time: {0}", reply.RoundtripTime);
            Console.WriteLine ("Time to live: {0}", reply.Options.Ttl);
            Console.WriteLine ("Don't fragment: {0}", reply.Options.DontFragment);
            Console.WriteLine ("Buffer size: {0}", reply.Buffer.Length);
        }
        else
        {
            Console.WriteLine (reply.Status);
        }
    }
