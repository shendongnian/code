            var input = new Dictionary<string, Dictionary<string, string>>();
            input.Add("test1", new Dictionary<string, string>());
            input["test1"].Add("1.2", "3");
            var output = input.ToDictionary(
                x => x.Key, 
                x => x.Value.ToDictionary(
                    y => double.Parse(y.Key), 
                    y => int.Parse(y.Value)
                )
            );
