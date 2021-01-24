    public static string cypher(string word)
    {
        // If word is null, we just return null.
        if(string.IsNullOrEmpty(word))
          return null;
    
        StringBuilder builder = new StringBuilder();
    
        foreach (char d in word)
        {
            char charCypher = System.Convert.ToChar((int)d+2);
            builder.Append(Convert.ToString(charCypher));
        }
    
        return builder.ToString();
    }
