    static void Main()
    {
        // create test collection
        var posData = new List<Dictionary<string,string>>();
        var test = new Dictionary<string,string>();
        test.Add("x", "y");
        posData.Add(test);
        // call the Where function
        var filteredList = posData.Where(x => MyFilter(x)).ToList();
        Console.WriteLine(filteredList.Count); // outputs "1"
    }
    static bool MyFilter(Dictionary<string,string> dict)
    {
        Console.WriteLine("hello"); // outputs "hello"
        return dict["x"] == "y";
    }
