        Dictionary<string, int> test = new Dictionary<string, int>();
        test.Add("dave", 12);
        test.Add("john", 14);
    
        // missing if there?
        test.TryGetValue("dave", out int value)
        {
    
            Console.WriteLine(value);
    
        }
