    const int wordCount = 50;
    string input = "Here comes your long text, use a smaller word count (like 4) for this example.";
    // First get each word.
    string[] words = input.Split(' ');
    List<string> groups = new List<string>();
    IEnumerable<string> remainingWords = words;
    do
    {
        // Then add them in groups of wordCount.
        groups.Add(string.Join(" ", remainingWords.Take(wordCount)));
        remainingWords = remainingWords.Skip(wordCount);
    } while (remainingWords.Count() > 0);
    // Finally, display them (only for a console application, of course).
    foreach (var item in groups)
    {
        Console.WriteLine(item);
    }
