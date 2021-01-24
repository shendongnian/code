    Dictionary<string, string> test = new Dictionary<string, string>()
    {
        {"{a}", "the new hero"},
        {"{b}", "of the new era"}
    };
    .....
    string input = GetInputString();
    int posStart = 0;
    while ((posStart = input.IndexOf("{", posStart)) != -1)
    {
        int posEnd = replacements.IndexOf("}", posStart+1);
        if(posEnd == -1)
            break;
        
        string sub = input.Substring(posStart, posEnd+1-posStart);
        if(test.ContainsKey(sub))
            input = input.Replace(sub, test[sub]);
        posStart++;
    }
    Console.WriteLine(input);
