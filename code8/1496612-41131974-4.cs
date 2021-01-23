    private async Task<List<PingReply>> PingAsync(List<Communication> theListOfIPs)
    {
        Ping pingSender = new Ping();
        var tasks = theListOfIPs.Select(ip => pingSender.SendPingAsync(ip, 10000));
        var results = await Task.WhenAll(tasks);
    
        return results.ToList();
    }
