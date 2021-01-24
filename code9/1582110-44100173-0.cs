    string input = @"
    *****
    ***
    *
    ***
    *****";
    var splited = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
    
    var maxLength = (int)(splited.Max(i => i.Length));
     
    var result = splited.Select(i => $"{new string(' ', (maxLength - i.Length + 1) / 2) }{i}").ToList();
    
    Console.WriteLine(string.Join(Environment.NewLine, result ));
