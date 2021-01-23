    async Task Contains(string file)
    {
        using ( StreamReader reader = new StreamReader(File.OpenRead(file))
        {
            string line = string.Empty;
            while( (line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(new char[] { ' ', ',', '.' });
                foreach(string word in uniqword)
                {
                    int howMany = words.Count(w => w.Equals(word);
                    if (no_doc_word.ContainsKey(word))
                        no_doc_word[word] += howMany;
                    else
                        no_doc_word.Add(word, howMany);
                }
            }
        }
    }
