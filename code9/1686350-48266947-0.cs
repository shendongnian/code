    List<string> list = new List<string>() { "{{test_data}}", "{{!test_data}}", "{{test_data1&&!test_data2}}" };
    
    foreach(string s in list)
    {
        string t = Regex.Replace(s, @"(?:{{2}|[^|]{2}|[^&]{2})\!?(\w+)(?:}{2})?",
               o => o.Value.Contains("!") ? "!mystring." + o.Groups[1].Value : "mystring." + o.Groups[1].Value);
    
        Console.WriteLine(t);
    }
    Console.ReadLine();
