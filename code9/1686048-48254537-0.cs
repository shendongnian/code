    static void Print(string input, string word)
    {
        if (word.All(ch => input.Contains(ch) &&
            word.GroupBy(c => c)
                .All(g => g.Count() <= input.Count(c => c == g.Key))))
            Console.WriteLine(word);
    }
