    string s = null;
    var collection = new string[] { "abb", "abd", "abc", null};
    switch (s)
    {
        case "xyz":
            Console.WriteLine("Is xyz");
            break;
    
        case var ss when (collection).Contains(s):
            Console.WriteLine("Is in list");
            break;
    
        default:
            Console.WriteLine("Failed!");
            break;
    
    }
