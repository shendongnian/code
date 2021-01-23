    string text = "Hello world ☀⛿END";
            
    Console.WriteLine(text);
    Console.WriteLine(Regex.Replace(text, @"\p{Cs}", ""));
    Console.WriteLine(Regex.Replace(text, @"[^\u0000-\u007F]+", ""));
    Console.WriteLine(text.Where(c => !Char.IsSurrogate(c)).ToArray());
