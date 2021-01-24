    public static string AdjustString(string str, List<string> userInput)
    {
        int i = 0;
        foreach (var input in userInput)
        {
            var searchedSubstring = $"[{i}]";
            str = str.Replace(searchedSubstring, input);
            i++;
        }
        return str;
    }
    static void UsgeExample()
    {
        var newString = AdjustString("[0][1][2]123[3]",
            new List<string> {"A", "B", "C", "D"});
    }
