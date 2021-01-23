    private static void CountWords()
        {
            const string fileName = "CountWords.txt";
            // Create a dummy file
            using (var sw = new StreamWriter(fileName))
            {
                sw.WriteLine("This is a short sentence");
                sw.WriteLine("This is a long sentence");
            }
            string text = File.ReadAllText(fileName);
            string[] result = text.Split(new[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            // Total word count
            Console.WriteLine("Total count: " + result.Count().ToString());
            // Now to illustrate getting the count of individual words
            var dictionary = new Dictionary<string, int>();
            foreach (string word in result)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word]++;
                }
                else
                {
                    dictionary[word] = 1;
                }
            }
            foreach (string key in dictionary.Keys)
            {
                Console.WriteLine(key + ": " + dictionary[key].ToString());
            }
        }
