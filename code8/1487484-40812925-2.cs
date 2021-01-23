            var variables = new Dictionary<string, string>();
            variables.Add("1","test1"); 
            variables.Add("5","test1");
            string[] s = new string[] { "1", "2", "3" };
            // returns Enumerable with keyvaluepair string string
            var value = variables.Where(x => s.Contains(x.Key));
  
           // some logic to read the result
           foreach (var key in value)
                Console.WriteLine(key.Key);
           
