    using System.Net.NetworkInformation;
    
    // Implementation 
    using (var ping = new Ping())
    {
       var reply = ping.Send("www.google.com");
       if (reply != null && reply.Status != IPStatus.Success)
       {
          // Raise an event
          // you might want to check for consistent failures 
          // before signalling a the Internet is down
       }
    }
    // Or if you wanted to get fancy ping multiple sources
    private async Task<List<PingReply>> PingAsync(List<string> listOfIPs)
    {
        Ping pingSender = new Ping();
        var tasks = listOfIPs.Select(ip => pingSender.SendPingAsync(ip, 2000));
        var results = await Task.WhenAll(tasks);
    
        return results.ToList();
    }
