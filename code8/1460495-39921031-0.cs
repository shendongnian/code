    static public int[] ParserInPlace(string s)
    {
        var result = new int[3];
        var x = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                x++;
                continue;
            }
            result[x] = result[x] * 10 + (s[i] - '0');
        }
            
        return result;
    }
