    Dictionary<string, int> dMyobject = new Dictionary<string, int>();
    while (!stRead.EndOfStream)
                {
                    var readedLine = stRead.ReadLine();
                    if (!string.IsNullOrWhiteSpace(readedLine))
                    {
                        int readedLineTime = Convert.ToInt32(readedLine.Substring(09, 02));
                        string sDate = readedLine.Substring(0, 11);
                        MatchCollection collection = Regex.Matches(readedLine, @"D;");
                        countedChars = collection.Count;
                        if (!dMyobject.Keys.Contains(sDate))
                        {
                            dMyobject.Add(sDate, collection.Count);
                        }
                        else
                        {
                            dMyobject[sDate] = dMyobject[sDate] + collection.Count;
                        }
                    }
                    textfileContent += readedLine + Environment.NewLine;
                    i++;
                }
