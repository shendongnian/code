    var myDict = new Dictionary<string, int>();
    // Adding values
    myDict.Add("foo", 3);
    myDict["bar"] = 8; // Alternative syntax
    // Getting values
    int bar =  myDict["bar"];
    bool fooExists = myDict.ContainsKey("foo"); // true
    // Safe get
    int foo;
    bool ableToGetFoo = myDict.TryGetValue("foo", out foo);
    // Splitting
    var allKeys = myDict.Keys;
    var allValues = myDict.Values;
    
