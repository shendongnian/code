    var objectWithNewestTestDate = engineList.Join(testList,
                                         engine => engine.EngineID,
                                         test => test.EngineID,
                                         (engine, test) => new
                                         {
                                             Engine = engine,
                                             Test = test
                                         }).OrderBy(x => x.Test.TestDate).Select(x => new { x.Engine, x.Test.Value1, x.Test.Value2 }).LastOrDefault();
     
