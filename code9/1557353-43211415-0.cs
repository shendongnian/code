    void Main()
    {
        string test = "This is a string";
        string result = PlainToHex(test);
        
        Console.WriteLine(result);
    }
    
    public string PlainToHex(string inputString)
    {
        return string.Join("", inputString.Select(c => ((int)c).ToString("X2")).ToArray());
    }
