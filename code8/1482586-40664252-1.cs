    public string anonymizeString(string input)
    {
        if (!string.IsNullOrEmpty(input) && input.Length > 5)
        {
            return "XXXX" + input.Substring(4, 2);
        }
        else
        {
            return input;
        }
    }
