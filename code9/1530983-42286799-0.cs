    async Task<List<PingReply>> PingAsync()
    {
        var pingTargetHosts = await GetIPs();
        var pingTasks = pingTargetHosts.Select(host => await new Ping().SendPingAsync(host, 2000)).ToList();
        var pingResults = await Task.WhenAll(pingTasks);
        return pingResults.ToList();
    }
