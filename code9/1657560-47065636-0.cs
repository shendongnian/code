    string textToCount = "...";
    // second step, split text by delimiters of your own
    List<string> words = textToCount.Split(' ', ',', '!', '?', '.', ';', '\r', '\n') // split by whatever characters
                .Where(s => !string.IsNullOrWhiteSpace(s))                           // eliminate all whitespaces
                .Select(w => w.ToLower())                                            // transform to lower for easier comparison/count
                .ToList();
    // use LINQ helper method to group words and project them into dictionary
    // with word as a key and value as total number of word appearances
    // this is the actual magic. With this in place, it's easy to get statistics.
    var groupedWords = words.GroupBy(w => w)
       .ToDictionary(k => k.Key, v => v.Count());`
    // to get various statistics
    // total different words - count your dictionary entries
    groupedWords.Count();
    // the most often word - looking for the word having the max number in the list of values
    groupedWords.First(kvp => kvp.Value == groupedWords.Values.Max()).Key
    // mentioned this many times
    groupedWords.Values.Max()
    // similar for min, just replace call to Max() with call to Min()
    // print out your dictionary to see for every word how often it's metnioned
    foreach (var wordStats in groupedWords)
    {
        Console.WriteLine($"{wordStats.Key} - {wordStats.Value}");
    }
    
