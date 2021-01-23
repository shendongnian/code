    string[] textLines = File.ReadAllLines(@"c:\Users\Darren\Desktop\Hello.txt");
    var results = new List<string>();
    foreach(var line in textLines)
    {
         var result = Regex.Replace(line, @"_(.*)\s", match =>
            {
                return $"~{match.Groups[1].Value.ToUpper()} ";
            });
        results.Add(result);
    }
    File.WriteAllLines(@"c:\Users\Darren\Desktop\newHello.txt", results.ToArray());
