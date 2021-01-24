    public static class StringExtensions
    {
        public static GetValueOrStringEmpty(this string input)
        {
            return string.IsNullOrEmpty(input) 
                  ? string.Empty 
                  : input;
        }
    }
