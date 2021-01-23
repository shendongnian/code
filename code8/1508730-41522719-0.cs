    public void searchForWord()
            {
                using (StreamReader fs = File.OpenText(filePath))
                {
    
                    int count = 0; //counts the number of times wordResponse is found.
                    int lineNumber = 0;
                    while (!fs.EndOfStream)
                    {
                        string line = fs.ReadLine();
                        lineNumber++;
                        int position = line.IndexOf(wordSearch);
                        int i = 0;
                        while ((i = line.IndexOf(wordSearch, i)) != -1)
                        {
                            i++;
                            if (position != -1)
                            {
                                count++;
                                Console.WriteLine("Match#{0} line {1}: {2}", count, lineNumber, wordSearch);
                            }
                        }
    
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("your word was not found!");
                    }
                    else
                    {
                        Console.WriteLine("Your word " + "'" + wordSearch + "'" + " was found " + count + " times!");
                    }
                    Console.WriteLine("Press enter to quit.");
                    Console.ReadKey();
                }
            }
