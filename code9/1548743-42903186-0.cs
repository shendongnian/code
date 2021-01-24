    var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,     "doc.txt");
            var theWholeFile = File.ReadLines(fileName)
                .Select((line, index) => new LineInformation { Line = line, Index = index}).ToList();
            var lastValue = string.Empty;
            foreach (var x in theWholeFile)
            {
               //The first date will be printed no matter what
                if (lastValue == string.Empty)
                {
                    Console.WriteLine(DateTime.ParseExact(x.Line,"mm/dd/yyyy", CultureInfo.InvariantCulture));
                    lastValue = x.Line;
                }
                else
                {
                    if (DateTime.Parse(x.Line) > DateTime.Parse(lastValue))
                    {
                        Console.WriteLine(DateTime.ParseExact(x.Line, "mm/dd/yyyy", CultureInfo.InvariantCulture));
                    }
                    lastValue = x.Line;
                }
                
            }
