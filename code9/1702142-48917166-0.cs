    var propertyName1 = 1000;
    var propertyName2 = 2000;
    // List of key value pairs
    var myList = new List<KeyValuePair<string, int>>();
    myList.Add(new KeyValuePair<string, int>(nameof(propertyName1), propertyName1));
    myList.Add(new KeyValuePair<string, int>(nameof(propertyName2), propertyName2));
    // Dictionary
    var myDict = new Dictionary<string, int>();
    myDict[nameof(propertyName1)] = propertyName1;
    myDict[nameof(propertyName2)] = propertyName2;
    // List of tuples
    var myTupleList = new List<Tuple<string, int>>();
    myTupleList.Add(new Tuple<string, int>(nameof(propertyName1), propertyName1));
    myTupleList.Add(new Tuple<string, int>(nameof(propertyName2), propertyName2));
