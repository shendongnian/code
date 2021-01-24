    static void Main()
    {
        var temp = "'ADDR_LINE_2','MODEL','TABLE',5,'S','Y','C40','MUL,NBLD,NITA,NUND','','Address line 2'";
        var parts = SplitString(temp).ToArray();
        parts[7] = null;
        var ret = string.Join(",", parts);
        //ret == "'ADDR_LINE_2','MODEL','TABLE',5,'S','Y','C40',,'','Address line 2'"
    }
    public static IEnumerable<string> SplitString(string input, char delimiter = ',', char quote = '\'')
    {
        string temp = "";
        bool skipDelimiter = false;
        foreach (var c in input)
        {
            if (c == quote)
                skipDelimiter = !skipDelimiter;
            else if (c == delimiter && !skipDelimiter)
            {
                //do split
                yield return temp;
                temp = "";
                continue;
            }
            temp += c;
        }
        yield return temp;
    }
