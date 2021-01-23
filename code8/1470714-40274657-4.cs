    public IList<string> GetValues(params IEnumerable<string> prompts)
    {
        var results = new List<string>();
        int y = Console.CursorTop;
        foreach (string prompt in prompts)
        {
            Console.WriteLine(prompt);
        }
        int i = 0;
        foreach (string prompt in prompts)
        {
            Console.SetCursorPosition(prompt.Length + 1, y + i);
            results.Add(Console.ReadLine());
            i++;
        }
        return results;
    }
