    string content = @"abba@aa.com dddb@bdd.com ""Information"" ""Hi there""";
    
    string firstEmail = content.Substring(0, content.IndexOf(" ", StringComparison.Ordinal));
    string secondEmail = content.Substring(firstEmail.Length, content.IndexOf(" ", firstEmail.Length + 1) - firstEmail.Length);
    
    int firstQuote = content.IndexOf("\"", StringComparison.Ordinal);
    string subjectandMessage = content.Substring(firstQuote, content.Length - content.IndexOf("\"", firstQuote, StringComparison.Ordinal));
        
    String[] words = subjectandMessage.Split(new string[] { "\" \"" }, StringSplitOptions.None);
                
    Console.WriteLine(firstEmail);
    Console.WriteLine(secondEmail);
    Console.WriteLine(words[0].Remove(0,1));
    Console.WriteLine(words[1].Remove(words[1].Length -1));
