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
                string sDate = readedLine.Substring(0, 11).Trim();
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
   
        var date = DateTime.Parse(dMyobject.First().Key);
        var beginOfMonth = new DateTime(date.Year, date.Month, 1);
        var days = new Dictionary<string, int>();
        for (var x = 0; x < DateTime.DaysInMonth(date.Year, date.Month); x++)
        {
            days.Add(beginOfMonth.AddDays(x).ToString("yyyy-MM-dd"), 0);
        }
        foreach (var item in days)
        {
            textfileOutput += (dMyobject.ContainsKey(item.Key) ? (item.Key + "  " + dMyobject[item.Key]) : (item.Key + "  0")) + Environment.NewLine;
        }
    }
