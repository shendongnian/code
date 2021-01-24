    public static IEnumerable<string[]> GetValues(string allLines)
    {
        using (var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(new StringReader(allLines)))
        {
            parser.HasFieldsEnclosedInQuotes = true;
            parser.Delimiters = new[] { "," };
            while (!parser.EndOfData)
            {
                string[] nextLineFields = parser.ReadFields();
                yield return nextLineFields;
            }
        }
    }
