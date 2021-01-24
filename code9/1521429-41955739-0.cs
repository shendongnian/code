    public static string Extract(string str, char splitOn)
    {
        var split = false;
        var count = 0;
        var bracketCount = 0;
        foreach (char c in str)
        {
            count++;
            if (split && c == splitOn)
               return str.SubString(0, count);
            if (c == '[')
            {
                 bracketCount++;
                 split = false;
            }
            else if (c == ']')
            {
                 bracketCount--;
                 
                 if (bracketCount == 0)
                 { 
                     split = true;
                 }
                 else if (bracketCount < 0)
                     throw new FormatException(); //?
            }
        }
        
        return str;
    }
