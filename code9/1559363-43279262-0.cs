    using (StreamReader sr = new StreamReader(f))
    {
                    string currentLine;
                    int id = 0;
                    using (StreamWriter files = File.AppendText(dir + newfilename))
                    {
                        while ((currentLine = sr.ReadLine()) != null)
                        {
                            string row = currentLine.ToString();
                            string FirstTwoCharacters = currentLine.Substring(0, 2);
                            if (FirstTwoCharacters == "01")
                            {
                                id = id + 1;
                                row += "*" + id.ToString();
                                files.WriteLine(row);
                                
                            }
                            else
                            {
                                row += "*" + id.ToString();
                                files.WriteLine(row);
                            }
                        }
                    }
                }
