    static public int[] ParserNoSplit(string s)
    {
        int[] result = new int[3];
        int x = 0;
        int b = 0;
        for(var i=0;i<s.Length;i++)
        {
            if(s[i] == ' ')
            {
                result[x++] = int.Parse(s.Substring(b, i - b));
                b = i + 1;
            }
        }
        result[x] = int.Parse(s.Substring(b));
        return result;
    }
