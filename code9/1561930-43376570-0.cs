        private void RemoveStopWords()
        {
            HashSet<string> stopWords = new HashSet<string>();
            using (var stopWordReader = new StreamReader("stopword.txt"))
            {
                string line2;
                while ((line2 = stopWordReader.ReadLine()) != null)
                {
                    string[] words2 = line2.Split('\n');
                    for (int i = 0; i < words2.Length; i++)
                    {
                        stopWords.Add(words2[i].ToLower());
                    }
                }
            }
            var fileWords = new HashSet<string>();
            for (int fileNumber = 1; fileNumber <= 49; fileNumber++)
            {               
                using (var reader = new StreamReader("D" + fileNumber.ToString() + ".txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        foreach(var word in line.Split(' '))
                        {
                            fileWords.Add(word.ToLower());
                        }
                    }
                }
            }
            fileWords.ExceptWith(stopWords);
            textBox1.Text = fileWords.Count().ToString();
        }
