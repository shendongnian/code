            private IEnumerable<string> translateData(string[] Collection)
            {
                //The resulting string collection.
                var resultCollection = new ConcurrentBag<string>();
    
                Dictionary dict = new Dictionary();
    
                Parallel.ForEach(Collection,
                    value =>
                    {
                        var person = dict.getNewValue(param1, param2, value.Substring(0, 10));
                        value.Remove(0, 10);
                        resultCollection.Add(person.Property1 + value);
                    });
    
                return resultCollection;
            }
