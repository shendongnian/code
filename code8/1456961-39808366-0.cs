Regex pattern: ([\"].*[\"])
            List<string> input = new List<string>();
            input.Add("= (value 1,value 2,\"value3,value4,value5\",value 6)");
            input.Add("\"(value 1,value 2,\"value 3, value 4\",value 5,value 6)\"");
            var regex = new Regex("([\"].*[\"])");
            List<string> output = input.Select(data => regex.Replace(data, m=> m.Value.Replace(',','@'))).ToList();
            foreach(string dat in output)
                Console.WriteLine(dat);
