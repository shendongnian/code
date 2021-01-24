    while ((line = inputStream.ReadLine()) != null)
                        {
                            string outputLine;
                            if (line.Contains("Line1"))
                            {
                                
                                outputLine = line + inputStream.ReadLine() + inputStream.ReadLine();
                                match.Add(outputLine);
                            }
                           
                        }
