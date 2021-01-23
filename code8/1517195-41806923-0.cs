    List<string> stringList = new List<string>();
    stringList.Add("some string"); // we are safe
    List<object> objectList = stringList;
    objectList.Add((new Object()); // Aargh! 
    // we are trying to put an object to a list of strings!
