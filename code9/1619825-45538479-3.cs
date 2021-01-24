    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace SQLLeftJoin
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                var engineList = new List<Engine>
                {
                    new Engine{ EngineID = "1"},
                    new Engine{ EngineID = "2"},
                    new Engine{ EngineID = "3"}
                };
    
                var testList = new List<Test>
                {
                    new Test{TestID = "1", EngineID = "1", TestDate = DateTime.Now},
                    new Test{TestID = "2", EngineID = "1", TestDate = DateTime.Now},
                    new Test{TestID = "3", EngineID = "2", TestDate = DateTime.Now},
                    new Test{TestID = "4", EngineID = "2", TestDate = DateTime.Now},
                    new Test{TestID = "5", EngineID = "3", TestDate = DateTime.Now},
                    new Test{TestID = "6", EngineID = "3", TestDate = DateTime.Now},
                    new Test{TestID = "7", EngineID = "3", TestDate = DateTime.Now},
                };
    
                var listOfEnginesWithTestData = engineList.Join(testList,
                                                 engine => engine.EngineID,
                                                 test => test.EngineID,
                                                 (engine, test) => new
                                                 {
                                                     Engine = engine,
                                                     Test = test
                                                 }).Select(x => new { x.Engine, x.Test.Value1, x.Test.Value2 }).ToList();
            }
        }
    
        class Engine
        {
            public string EngineID { get; set; }
        }
    
        class Test
        {
            public string TestID { get; set; }
            public string EngineID { get; set; }
            public DateTime TestDate { get; set; }
            public object Value1 { get; set; }
            public object Value2 { get; set; }
        }
    }
