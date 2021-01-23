    static void Main(string[] args)
    {
        string input = "Product #_TemplateName_# #_Full_Product_Name_# more text. text text #_Short_Description_#",
            pattern = "#_[a-zA-Z_]*_#";
        Match match = Regex.Match(input, pattern);
        while (match.Success)
        {
            Console.WriteLine(match.Value);
            match = match.NextMatch();
        }
        Console.ReadLine();
    }
