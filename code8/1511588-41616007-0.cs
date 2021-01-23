    using (var stream = File.OpenRead(fileSaveLocation))
    {
        using (var reader = new StreamReader(stream))
        {
            // Get the header and rows as a two-item tuple
            var data = CsvParser.ParseHeadAndTail(reader, ',', '"');
            
            // Get header and and rows into separate variables
            var header2 = data.Item1;
            var lines = data.Item2;
            // This is where you get the rows you want
            // So in this example, we'll skip the first
            // 3 lines and then get the next 10 lines
            var filteredLines = lines.Skip(3).Take(10);
            // Iterate through the lines and do whatever you need to do
            foreach (var line in filteredLines)
            {
                for (var i = 0; i < header2.Count; i++)
                {
                    if (!string.IsNullOrEmpty(line[i]))
                    {
                        sb.Append(header2[i] + "=" + line[i]);
                        sb.Append(Environment.NewLine);
                    }
                }
            }
        }
    }
