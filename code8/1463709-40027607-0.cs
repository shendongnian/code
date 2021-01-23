    static void Main(string[] args)
    {
        string input = "Product #TemplateName# #_Full_Product_Name_# more text. text text #_Short_Description_#",
            pattern = "#[a-zA-Z_]*#";
        Match match = Regex.Match(input, pattern);
        while (match.Success)
        {
            Console.WriteLine(match.Value);
            match = match.NextMatch();
        }
        Console.ReadLine();
    }
