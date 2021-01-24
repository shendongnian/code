    using (StreamReader stRead = new StreamReader(@"c:\test.txt"))
    {
        string filenameDate = "test";
        string textfileContent = string.Empty;
        int i = 0;
        string textfileOutput = string.Empty;
        Dictionary<string, int> dMyobject = new Dictionary<string, int>();
        while (!stRead.EndOfStream)
        {
            var readedLine = stRead.ReadLine();
            if (!string.IsNullOrWhiteSpace(readedLine))
            {
                string sDate = readedLine.Substring(0, 11);
                MatchCollection collection = Regex.Matches(readedLine, @"D;");
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
   
        foreach (var item in dMyobject)
        {
            textfileOutput += (item.Key + "  " + item.Value) + Environment.NewLine;
        }
    }
