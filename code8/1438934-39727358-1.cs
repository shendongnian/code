    var myDict = new MultiKeyDictionary<string, double, double, string>
    {
        {"Goodbye", 0.55, 9.00, "yaya"} // collection initializer works fine
    };
    myDict.Add("Hello", 1.11, 2.99, "hi");
    Console.WriteLine(myDict.ContainsKey("Hello", 1.11, 2.99));
    Console.WriteLine(myDict.ContainsKey("a", 1.11, 2.99));
    Console.WriteLine(myDict["Hello", 1.11, 2.99]);
    myDict.Add(KeyTriple.Create("Hello", 1.11, 2.99), "gh"); // bang!
