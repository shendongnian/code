    public static string InfoParse(string input)
    {
        //string extract = input;
        string extract = input.Substring(0, input.IndexOf(" more information"));
        extract = extract.Split(' ').Last();
        return extract;
    }
