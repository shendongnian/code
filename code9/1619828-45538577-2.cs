    var lastTestQuery = _context.Test
        .FromSql(@"
            SELECT t.* FROM Test t
            WHERE t.TestDate = (SELECT MAX(t2.TestDate) FROM Test t2 WHERE t2.EngineId = t.EngineId)"
        );
    var enginesWithLastTest = _context.Engine
        .GroupJoin(lastTestQuery, engine => engine.EngineId, test => test.EngineId, (engine, tests) => new {
            Engine = engine,
            LastTests = tests.DefaultIfEmpty()
        })
        .ToList();
    
    foreach (var item in enginesWithLastTest)
    {
        var eng = item.Engine;
        var test = item.LastTests.FirstOrDefault();
        Console.WriteLine($"{eng.EngineId} {eng.Make} {eng.Model} {eng.SerialNumber} {test?.TestValue}");
    }
