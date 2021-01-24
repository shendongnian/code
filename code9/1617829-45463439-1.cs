    public static class StringExtensions
    {
        public static bool ShouldWeDeleteThisExcelLine(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return true;
            double someValue;
            if (double.TryParse(input, out someValue) == false)
                return true;
            return false;
        }
    }
