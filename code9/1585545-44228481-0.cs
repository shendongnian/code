    public string Normalize(string input, string prefix, string suffix)
    {
        // Validation
        int length = input.Length;
        int startIndex = 0;
        if(input.StartsWith(prefix))
        {
            startIndex = prefix.Length;
            length -= prefix.Length;
        }
    
        if (input.EndsWith (suffix))
        {
            length -= suffix.Length;
        }
    
        return input.Substring(startIndex, length);
    }
