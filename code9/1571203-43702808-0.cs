    string content = @"aa@aa.com bb@bb.com ""Information"" ""Hi there""";
    
    string firstEmail = content.Substring(0, content.IndexOf(" ", StringComparison.Ordinal));
    string secondEmail = content.Substring(firstEmail.Length + 1, content.IndexOf(" ", firstEmail.Length - 1, StringComparison.Ordinal));
    
    int firstQuote = content.IndexOf("\"", StringComparison.Ordinal);
    string subjectandMessage = content.Substring(firstQuote, content.Length - content.IndexOf("\"", firstQuote, StringComparison.Ordinal));
    
    String[] words = subjectandMessage.Split(new string[] { "\" \"" }, StringSplitOptions.None);
            
    Console.WriteLine(firstEmail);
    Console.WriteLine(secondEmail);
    Console.WriteLine(words[0].Remove(0,1));
    Console.WriteLine(words[1].Remove(words[1].Length -1));
