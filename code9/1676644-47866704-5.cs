    public static string cypher(string word)
    {
        // If word is null, we just return null.
        if(string.IsNullOrEmpty(word))
          return null;
    
        // Process string. This will return after first char...
        foreach (char d in word)
        {
            char charCypher = System.Convert.ToChar((int)d+2);
            return Convert.ToString(charCypher);
        }
    }
