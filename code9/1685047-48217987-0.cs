    public RiskDS()
    {
        Name = "Risk overview";
        Description = "Blaat";
        var netRisks = GetNetRisks(/* organization id */);
        Point = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GraphPoint>>(netRisks);
    }
