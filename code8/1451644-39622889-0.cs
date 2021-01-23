    [EnableQuery(MaxTop = 100)]
    public IQueryable<Productioncurvepnl> GetProductioncurvepnl()
    {
        Console.WriteLine("Starting query to ignite");
        var q = AIgniteClient.IgniteClient.Instance.ProductionCurvePnLCache.AsCacheQueryable().Select(c => c.Value);
        return q;
    }
