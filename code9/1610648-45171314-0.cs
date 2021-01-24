       private static IEnumerable<string> GetValues2(string line)
        {
            var insideQuotes = false;
            var insidePercent = false;
            var startValueIndex = 0;
            for (var i = 0; i < line.Length; i++)
            {
                if (!insideQuotes && line[i] == '%')
                {
                    insidePercent = !insidePercent;
                }
                if (line[i] == '"')
                {
                    insideQuotes = !insideQuotes;
                }
                if (insideQuotes || insidePercent || line[i] != ',')
                {
                    continue;
                }
                yield return line.Substring(startValueIndex, i - startValueIndex);
                startValueIndex = i + 1;
            }
        }
