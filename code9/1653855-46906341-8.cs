    static async Task<string> IPCheck(string address)
    {
        using (var cts = new CancellationTokenSource(2000))
        {
            var result = await SendPings(address, 5, cts.Token);
            return result;
        }
    }
    static async Task<string> SendPings(string address, int count, CancellationToken token)
    {
        var responses = new List<PingReply>(5);
        Ping currentPing = new Ping();
        for (int i = 0; i < count; i++)
        {
            if (token.IsCancellationRequested)
            {
                return "Cancelled!";
            }
            var replyPing = await currentPing.SendPingAsync(address, 1000);
            switch (replyPing.Status)
            {
                case IPStatus.Success:
                    responses.Add(replyPing);
                    break;
                case IPStatus.TimedOut:
                    responses.Add(replyPing);
                    Console.WriteLine($"Ping to {address} timed out.\n");
                    break;
                default:
                    responses.Add(replyPing);
                    break;
            }
        }
        var avgTime = responses.Average(resp => resp.RoundtripTime);
        return $"All pings returned. Average roundtrip {avgTime}";
    }
