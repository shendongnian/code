    Regex rgx = new Regex("[^a-zA-Z]");
    Console.WriteLine(useUnkownPack(rgx.Replace(inputValue, "")));
    ....
    public static bool useUnkownPack(string strTest)
    {
        List<string> unkownChars = new List<string> {"Unknown", "TBC", "TBA", "NA"};
        if(unkownChars.Contains(strTest, StringComparer.OrdinalIgnoreCase))
        {
           return false;
        }
        return true;
    }
