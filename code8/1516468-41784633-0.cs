    var dict = new Dictionary<string, int>();
    dict.Add("a", 3);
    dict.Add("b", 4);
    dict.Add("c", 5);
    dict.Add("d", 6);
    int value = 5; // or whatever
    string key = dict.Where(kvp => kvp.Value == value)
                        .Select(kvp => kvp.Key)
                        .FirstOrDefault();
