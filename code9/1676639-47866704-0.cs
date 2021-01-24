    public static string cypher(string word)
    {
        // If string is null, this foreach will be skipped.
        foreach (char d in word)
        {
            char charCypher = System.Convert.ToChar((int)d+2);
            return Convert.ToString(charCypher);
        }
    
        // If string is null, return null...
        return null;
    }
