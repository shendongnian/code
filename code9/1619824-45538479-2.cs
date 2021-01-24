    var listOfEnginesWithTestData = engineList.Join(testList,
                                         engine => engine.EngineID,
                                         test => test.EngineID,
                                         (engine, test) => new
                                         {
                                             Engine = engine,
                                             Test = test
                                         }).Select(x => new { x.Engine, x.Test.Value1, x.Test.Value2 }).ToList();
     
