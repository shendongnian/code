    static public int[] ParserNoSplitNoIntParse(string s)
    {
        int[] result = new int[3];
        int x = 0;
        int b = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                result[x++] = ParseVal(s.Substring(b, i - b));
                b = i + 1;
            }
        }
        result[x] = ParseVal(s.Substring(b));
        return result;
    }
    
    static int ParseVal(string s)
    {
        var result = 0;
    
        for (var i = 0; i < s.Length; i++)
        {
            result = result * 10 + (s[i] - '0');
        }
    
        return result;
    }
