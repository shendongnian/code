    private static void RemoveLines(string lineToRemove, bool skipPrevious, bool skipNext)
    {
                string previousLine = string.Empty;
                string currentLine;
                using (StreamReader sr = File.OpenText(@"input.txt"))
                {
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        if (currentLine == lineToRemove)
                        {
                            if (skipPrevious)
                            {
                                previousLine = string.Empty;
                            }
    
                            if (skipNext)
                            {
                                currentLine = string.Empty;
                            }
                        }
    
                        if (previousLine != string.Empty && previousLine != lineToRemove) 
                        {
                            using (StreamWriter sw = File.AppendText(@"output.txt"))
                            {
                                sw.WriteLine(previousLine);
                            }
                        }
                        previousLine = currentLine;
                    }
                }
    }
