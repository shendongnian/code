            var variables = new Dictionary<string, string>();
            variables.Add("1","test1"); 
            variables.Add("5","test1");
            string[] s = new string[] { "1", "2", "3" };
            var value = variables.Where(x => s.Contains(x.Key)); // returns Enumerable with result (will have one result)
            [![Output value][1]][1]
            // some logic to read the result
