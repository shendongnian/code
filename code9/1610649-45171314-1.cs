       private static IEnumerable<string> GetValues2(string line)
        {
            bool insideQuotes = false;
            bool insidePercent = false;
            int startValueIndex = 0;
            for (int i = 0; i < line.Length; i++)
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
