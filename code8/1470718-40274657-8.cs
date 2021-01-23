    IList<string> PromptUser(params IEnumerable<string> prompts)
    {
        var results = new List<string>();
        int i = 0; //manual int w/ foreach instead of for(int i;...) allows IEnumerable instead of array
        foreach (string prompt in prompts)
        {
            Console.WriteLine(prompt);
            i++;
        }
        //do this after writing prompts, in case the window scrolled
        int y = Console.CursorTop - i; 
        if (y < 0) throw new Exception("Too many prompts to fit on the screen.");
        i = 0;
        foreach (string prompt in prompts)
        {
            Console.SetCursorPosition(prompt.Length + 1, y + i);
            results.Add(Console.ReadLine());
            i++;
        }
        return results;
    }
