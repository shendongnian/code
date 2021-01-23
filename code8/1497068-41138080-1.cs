    static void Main(string[] args)
    {
        List<string> delim = new List<string> { "city", "street" };
        string formattedText = "strxx street BakerStreet cityxx city London";
        List<string> results = new List<string>();
        foreach (var del in delim)
        {
            string s = Regex.Match(formattedText, del + @"\s\w+\b").Value;
            if (!String.IsNullOrWhiteSpace(s))
            {
                results.Add(s.Split(' ')[1]);
            }
        }            
        Console.WriteLine(String.Join("\n", results));
        Console.ReadKey();
    }
