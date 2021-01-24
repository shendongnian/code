                using (StreamReader sr = new StreamReader(@"C:\path\to\file.csv"))
                {
                    string currentLine;
                    while((currentLine = sr.ReadLine()) != null)
                    {
                        string[] lineArr = line.Split(',');
                        foreach(string subLine in lineArr)
                        {
                            Console.WriteLine(subline);
                        }
                        Console.Read(); // Awaits user input in order to proceed
                    }
                }
