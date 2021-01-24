    Dictionary<int, int> dictionary = new Dictionary<int, int>();
    dictionary.Add(1, 2);
     dictionary.Add(3, 4);
    dictionary.Add(4, 3);
    var result = dictionary.Distinct(new KeyValuePairEqualityComparer()).ToDictionary(x => x.Key, x => x.Value);
        }
