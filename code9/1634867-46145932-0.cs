    public static string GetHostedRecordSet()
    {
        var request = new ListHostedZonesRequest()
        {
            MaxItems = "1"
        };
    
        var list = client.ListHostedZones(request);
    
        StringBuilder result = new StringBuilder();
        foreach (var hostedId in list.HostedZones)
        {
            result.Append(hostedId.Id).Append(",");
        }
    
        return result.ToString(0, Math.Max(0, result.Length - 1);
    }
