    public static IEnumerable<string> GetHostedRecordSet()
    {
        var request = new ListHostedZonesRequest()
        {
            MaxItems = "1"
        };
        var list = client.ListHostedZones(request);
        return list.HostedZones
            .Select(z => z.Id);
    }
