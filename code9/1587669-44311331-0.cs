    string contents = File.ReadAllText(@"PATH_TO_FILE");
    string[] singleContentCollection = contents.Split(new string[] { "eof" }, StringSplitOptions.RemoveEmptyEntries);
    foreach (var singleContent in singleContentCollection)
    {
        string[] contentLines = singleContent.Split(new char[] { '[' }, StringSplitOptions.None);
        foreach (var contentLine in contentLines)
        {
            string[] contentLineItems = contentLine.Split(new char[] { ']' }, StringSplitOptions.None);
            string Label = contentLineItems[0];
            Console.Write(Label.Replace(Environment.NewLine, string.Empty));
                    
            if (contentLineItems.Length > 1)
            {
                Console.Write(" : ");
            
    Console.Write(contentLineItems[1].TrimStart(',').Replace(Environment.NewLine, string.Empty));
            }
            Console.WriteLine();
        }
        Console.WriteLine("<----------    End Of Item   ------------>");
    }
