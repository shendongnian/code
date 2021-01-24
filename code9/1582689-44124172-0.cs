    static class Quotes
    {
        public static StringBuilder DoubleQuotes(params string[] parameters)
        {
            char quote = '\u0022';
            string value = null;
            
            for (int i = 0; i < parameters.Length; i++)
            {
            parameters[i] = 
                parameters[i]
                    .Insert(0, quote.ToString()) 
                    .Insert(parameters[i].Length + 1, quote.ToString());
                    
                value += parameters[i];			
            }
        
        value = String.Join(", ", parameters);
        StringBuilder builder = new StringBuilder(value);
        
        return builder;
    }
