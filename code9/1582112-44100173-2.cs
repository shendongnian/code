    string Foo(string input)
    {
        var result = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
    
        var maxLength = (int)(result.Max(i => i.Length));
    
        var temp = result.Select(i => ((maxLength - i.Length + 2) / 2)).ToList();
    
        var newResult = result.Select(i => $"{new string(' ', (maxLength - i.Length + 1) / 2) }{i}").ToList();
    
        return string.Join(Environment.NewLine, newResult);
    }
