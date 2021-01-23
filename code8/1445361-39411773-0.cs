    var list = new List<string>() { .... , "String C", "String D", ... };
    // if you still need dict, then:
    var dictionary = list.ToDictionary(z => new object());
    // whatever, find the "String D"
    var knownValue = "String C";
    var ret = list.SkipWhile(z => z != knownValue).Skip(1).First();
