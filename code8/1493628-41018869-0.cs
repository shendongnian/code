    public class ParseException : FormatException
    {
        public string OriginalValue { get; }
        public ParseException(string message, string originalValue)
            : base(message)
        {
            OriginalValue = originalValue;
        }
    }
    public class ExtendedParsing
    {
        public int ParseInt32(string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            throw new ParseException($"Unable to parse \"{value}\"", value);
        }
    }
