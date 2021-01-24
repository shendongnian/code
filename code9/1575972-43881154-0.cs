        string input = TextEditor.text;
        string[] inputWords = input.Split(' ');
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        foreach (string word in inputWords)
        {
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts.Add(word, 1);
            }
        }
