    public static string cypher(string word)
    {
        StringBuilder builder = new StringBuilder();
        // If string is null, this foreach will be skipped.
        foreach (char d in word)
        {
            char charCypher = System.Convert.ToChar((int)d+2);
            builder.Append(Convert.ToString(charCypher));
        }
    
        return builder.ToString();
    }
