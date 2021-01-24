    void Main()
    {
        // A dictionary where every key points to its replacement char
        Dictionary<char, char> replacements = new Dictionary<char, char>()
        {
            {'(', ')'},
            {')', '('},
        };
        
        string source = ")Hi(";
    
        StringBuilder sb = new StringBuilder();
        foreach (char c in source)
        {
            char replacement = c;
            if(replacements.ContainsKey(c))
                replacement = replacements[c];
            sb.Append(replacement,1);
        
        }
        Console.WriteLine(sb.ToString());
    }
