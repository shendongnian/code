    [Test]
    public void SelectPerformance()
    {
         _cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
         var session = _cluster.Connect("dm");
         var ps = session.Prepare(@"SELECT symbol, value_type, as_of_day, revision_timestamp_utc, value FROM daily_data_by_day WHERE symbol = ? AND  value_type = ? AND as_of_day >= ? AND as_of_day < ?");
         _stopwatch = new Stopwatch();
    var items = new[]
    {
        // 20 different items...
    };
    foreach (var item in items)
    {
        var watch = Stopwatch.StartNew();
        var rows = ExecuteQuery(session, ps, item.Symbol, item.FieldType, item.StartDate, item.EndDate);
        watch.Stop();
        Console.WriteLine($"{watch.ElapsedMilliseconds}\t{rows.Length}");
    }
         Console.WriteLine($"Average Execute: {   _stopwatch.ElapsedMilliseconds/items.Length}");
         _cluster.Dispose();
    }
    private Row[] ExecuteQuery(Session session, PreparedStatement ps, string symbol, int fieldType, LocalDate startDate, LocalDate endDate)
    {
         var statement = ps.Bind(symbol, fieldType, startDate, endDate);
    statement.EnableTracing();
         _stopwatch.Start();
         var rowSet = session.Execute(statement);
         _stopwatch.Stop();
         return rowSet.ToArray();
    }
