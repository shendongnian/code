    static string AlignCenter(string input)
    {
        var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
    
        var maxLength = (int)(lines.Max(i => i.Length));
     
        var result = lines.Select(i => $"{new string(' ', (maxLength - i.Length + 1) / 2) }{i}").ToList();
    
        return string.Join(Environment.NewLine, result);
    }
