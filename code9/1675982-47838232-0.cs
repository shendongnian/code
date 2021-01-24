    public static class TextFieldParserExtensions
    {
        public static List<IGrouping<string, string[]>> ReadCellsWithDuplicatedCellValues(string path, int keyCellIndex, int nRowsToSkip /* = 0 */)
        {
            using (var stream = File.OpenRead(path))
            using (var parser = new TextFieldParser(stream))
            {
                parser.SetDelimiters(new string[] { "," });
                var values = parser.ReadAllFields()
                    // If your CSV file contains header row(s) you can skip them by passing a value for nRowsToSkip
                    .Skip(nRowsToSkip) 
                    .GroupBy(row => row.ElementAtOrDefault(keyCellIndex))
                    .Where(g => g.Count() > 1)
                    .ToList();
                return values;
            }
        }
        public static IEnumerable<string[]> ReadAllFields(this TextFieldParser parser)
        {
            if (parser == null)
                throw new ArgumentNullException();
            while (!parser.EndOfData)
                yield return parser.ReadFields();
        }
    }
