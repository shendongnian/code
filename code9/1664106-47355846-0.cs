    public string Summarize(string input, int length)
    {
        if (input.Length <= length) return input;
        string result = input.Substring(0, length) + System.Environment.NewLine + input.Substring(length, length/2);
        //You may want to add more logic or split the string at the previous whitespace
        return result;
    }
