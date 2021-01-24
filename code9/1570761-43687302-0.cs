    enum Code
    {
        Unknown = 0,
        Match = 'M',
        PartialMatch = 'P',
        NoMatch = 'N'
    }
    static class CodeExtensions
    {
        public static Code ToCode(this string value)
        {
            value = value.Trim();
            if (String.IsNullOrEmpty(value))
                return Code.Unknown;
            if (value.Length != 2)
                return Code.Unknown;
            return value[0].ToCode();
        }
        public static Code ToCode(this char value)
        {
            int numericValue = value;
            if (!Enum.IsDefined(typeof(Code), numericValue))
                return Code.Unknown;
            return (Code)numericValue;
        }
    }
