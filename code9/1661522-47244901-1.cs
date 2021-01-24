    var lines = new string[]
    {
        "line1  stringToFind1 stringToFind2",
        "line2 ",
        "line3 stringToFind3",
        "line4 stringToFind4 stringToFind5",
    };
    
    var stringsToFind = new string[]
    {
        "stringToFind1",
        "stringToFind2",
        "stringToFind3",
        "stringToFind4",
        "stringToFind5",
    };
      
    foreach (string line in lines)
    {
        foreach (string stringToFind in stringsToFind)
        {
            if (line.Contains(stringToFind))
            {
                Console.WriteLine(string.Format("Found {0} at line {1}", stringToFind, line));
            }
        }
    }
