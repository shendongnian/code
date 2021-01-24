    var query =
        from engine in _context.Engine
        join test in (
            from t in _context.Test
            where t.TestDate == (from t2 in _context.Test where t2.EngineId == t.EngineId select t2.TestDate).Max()
            select t
        ) on engine.EngineId equals test.EngineId into td
        from latestTest in td.DefaultIfEmpty()
        orderby engine.SerialNumber ascending
        select new EngineVM {
            EngineId = engine.EngineId,
            Make = engine.Make,
            Model = engine.Model,
            SerialNumber = engine.SerialNumber,
            LastTestValue1 = latestTest != null ? (decimal?) latestTest.TestValue : null
        };
    
    var enginesWithLastTest = query.ToList();
    
    foreach (var eng in enginesWithLastTest)
    {
        Console.WriteLine($"{eng.EngineId} {eng.Make} {eng.Model} {eng.SerialNumber} {eng.LastTestValue1}");
    }
