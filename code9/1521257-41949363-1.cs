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
   
    var prevDate = string.Empty; // store previous date
    foreach (var item in dMyobject)
    {
        if (!string.IsNullOrEmpty(prevDate))
        {
            var cur = DateTime.Parse(item.Key); // convert current key into date
            var prev = DateTime.Parse(prevDate);
            var dayDiff = cur.Day - prev.Day;
            for (var x = 0; x < dayDiff - 1; x++) // run through day difference, add it to the last date that was added
            {
                textfileOutput += (prev.AddDays(x + 1).ToString("yyyy-MM-dd") + "   0" + Environment.NewLine);
            }
        }
        textfileOutput += (item.Key + "  " + item.Value) + Environment.NewLine;
        prevDate = item.Key;
    }
    }
