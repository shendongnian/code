    void AddTest()
            {
                var dic1 = new Dictionary<string, string>();
                dic1.Add("Key", "Value");
                var dic2 = new ReadOnlyDictionary<string, string>(dic1);
                dic1.Add("Key2", "Value2"); //Now dic2 have 2 values too.
            }
