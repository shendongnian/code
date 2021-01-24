                    var mainDict = new Dictionary<string, Dictionary<string, List<string>>>()
            {
                {"Group1", new Dictionary<string, List<string>>{{"A", new List<string> {"bob", "steve", "greg"}}}},
                {"Group2", new Dictionary<string, List<string>>{{"B", new List<string> {"tom", "thomas", "justin", "lee"}}}},
                {"Group3", new Dictionary<string, List<string>>{{"C", new List<string> { "dustin", "rick" }}}}
            };
            var namesA = from m in mainDict where m.Value.ContainsKey("A") select m.Value.Values.First();
            var namesB = from m in mainDict where m.Value.ContainsKey("B") select m.Value.Values.First();
            var namesC = from m in mainDict where m.Value.ContainsKey("C") select m.Value.Values.First();
