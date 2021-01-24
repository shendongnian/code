    static void Main(string[] args)
    {
        string RegexString = @"(?=\d{4}[-]\d{2}[-]\d{2}[ ]\d{2}[:]\d{2}[:]\d{2}[,])";
        string Log4NetSample = Properties.Resources.Log4Net_Example;
        List<string> ParsedLogItems = new List<string>();
        foreach (var Item in Regex.Split(Log4NetSample, RegexString))
            if (Item.Trim() != string.Empty)
                ParsedLogItems.Add(Item);
    
    
        foreach (var Item in ParsedLogItems)
        {
            Console.WriteLine();
            Console.WriteLine("===== New Log Item =====");
            Console.WriteLine(Item);
        }
        Console.ReadLine();
    }
