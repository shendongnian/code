    private static void RemoveLines(string lineToRemove, bool skipPrevious, bool skipNext)
    {
                string previousLine = string.Empty;
                string currentLine;
                bool isNext = false;
                using (StreamWriter sw = File.CreateText(@"output.txt"))
                {
                    using (StreamReader sr = File.OpenText(@"input.txt"))
                    {
    
                        while ((currentLine = sr.ReadLine()) != null)
                        {
                            if (isNext)
                            {
                                currentLine = string.Empty;
                                isNext = false;
                            }
    
                            if (currentLine == lineToRemove)
                            {
                                if (skipPrevious)
                                {
                                    previousLine = string.Empty;
                                }
    
                                if (skipNext)
                                {
                                    currentLine = string.Empty;
                                    isNext = true;
                                }
                            }
    
                            if (previousLine != string.Empty && previousLine != lineToRemove)
                            {
                                sw.WriteLine(previousLine);
                            }
                            previousLine = currentLine;
                        }
                    }
                    if (previousLine != string.Empty && previousLine != lineToRemove)
                    {
                        sw.WriteLine(previousLine);
                    }
                }
    }
