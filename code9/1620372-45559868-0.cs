    using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
