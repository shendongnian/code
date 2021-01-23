    public static class TextFieldParserExtensions
    {
        public static IEnumerable<string []> ReadAllFields(this TextFieldParser parser)
        {
            if (parser == null)
                throw new ArgumentNullException();
            while (!parser.EndOfData)
                yield return parser.ReadFields();
        }
    }
