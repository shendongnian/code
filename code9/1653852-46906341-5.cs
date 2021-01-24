    async Task<string> IPCheck()
    {
        var cts= new CancellationTokenSource(2000);
        
        var result= await SendPing(5,cts.Token);
        return result;
    }
    async Task<string> SendPings(int count,CancellationToken token)
    {
        var responses = new List<IPStatus>(5);
        Ping currentPing = new Ping();
        for(int i=0;i<count;i++)
        {
            if (token.IsCancellationRequested)
            {
                return "Cancelled!";
            }
        var replyPing= await currentPing.SendPingAsync(addressString,1000);        
        switch(replyPint.Status)
        {
            case IPStatus.Success:
                responses.Add(replyPing);
                break;
            case IPStatus.Timeout:
                return  $"Ping to {addressString} timed out.\n";
            default:
                responses.Add(replyPing);
                break;
        }
        var avgTime = responses.Average(resp=>resp.RoundTripTime);
        return $"All pings returned. Average roundtrip {avgTime}";
    }
