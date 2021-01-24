            string filename = @"D:\text.txt";
            var words = new List<string>();
            char[] delims = { '.', '!', '?', ',', '(', ')', '\t', '\n', '\r', ' ' };
            try
            {
                using (var reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        words.AddRange(line.Split(delims, StringSplitOptions.RemoveEmptyEntries));
                    }
                }
            }
            // now you dont need to close stream because
            // using statement will handle it for you
            catch // appropriate exception handling
            {
            }
            foreach (string word in words)
            {
                wordListBox.Items.Add(word);
            }
