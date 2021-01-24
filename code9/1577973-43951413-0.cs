    void Main()
    {
        // A dictionary where every key points to its replacement char
        Dictionary<char, char> hs = new Dictionary<char, char>()
        {
            {'(', ')'},
            {')', '('},
        };
        
        string source = ")Hi(";
    
        StringBuilder sb = new StringBuilder();
        foreach (char c in source)
        {
            char replacement = c;
            if(hs.ContainsKey(c))
                replacement = hs[c];
            sb.Append(replacement,1);
        
        }
        Console.WriteLine(sb.ToString());
    }
