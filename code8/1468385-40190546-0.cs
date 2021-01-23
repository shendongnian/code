    public static string printStack(IEnumerable<string> stack)
    {
        string DisplayOutTxt = "";
        foreach (var obj in stack)
        {
            DisplayOutTxt += obj;
        }
        return DisplayOutTxt;
    }
