    Dictionary<string, Dictionary<string, string>> dict= new Dictionary<string, Dictionary<string, string>>();
            var query = from outer in dict
                      from inner in outer.Value
                      select outer.Key + "->>" + inner.Key + ", " + inner.Value;
            foreach (string item in query)
            { 
                //item
            }
