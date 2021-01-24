        Dictionary<string, string> dict = new Dictionary<string,string>();
        dict.Add("Hello", "Goodbye");
        dict.Add("Morning", "Evening");
        dict.Add("Blue", "Red");
        foreach(KeyValuePair<string,string> item in dict)
        {
            Console.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
        }
        Console.ReadLine();
