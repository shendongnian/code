     Dictionary<int, List<string>> myDictionary = new Dictionary<int, List<string>>();
            myDictionary.Add(1, new List<string>()
                {
                    "Oscar", "Pablo", "John"
                });
            myDictionary.Add(2, new List<string>()
                {
                    "Foo", "Hello", "World"
                });
            var result = myDictionary.Where(c => c.Value.Contains("Oscar") && c.Value.Contains("Pablo") && c.Value.Contains("John")).ToDictionary(c => c.Key, c => c.Value);
