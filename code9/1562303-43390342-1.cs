            var input = File.ReadLines("myFile").ToArray();
            var pTable = new PredicateTable<Word>();
            pTable.AddPredicate("def", x => x.Contains("Def"));
            pTable.AddPredicate("race", x => x.Contains("Race")); 
            pTable.AddPredicate("raceTod", x => x.Contains("Race") && x.Contains("TOD")); 
            var matches = new ORegex<string>("(?<g1>{race}{def})|(?<g2>{raceTod})", pTable).Matches(input)
            foreach(var m in matches)
            {
               var lines = m.Values.ToArray()
               var first = m.OCaptures["g1"];
               var second = m.OCaptures["g2"];
               //process your lines/groups
            }
