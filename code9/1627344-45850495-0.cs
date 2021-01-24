    public static class DateTimeExtensions
    {
        public static bool StrictTryParse(this string s, out DateTime result)
        {
            result = DateTime.MinValue;
            // List all the formats you want here.
            // Could move this out of the method, or make it a parameter.
            List<string> formats = new List<string> { "MM/dd/yyyy", "MM/dd/yy" };
            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(s, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
                    return true;
            }
            return false;
        }
    }
