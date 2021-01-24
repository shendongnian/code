    public static class CustomExtensions
    {
        public static string[] Split(this string stringToSplit, int count, params char[] separator)
        {
            // todo: add some parameter validation checks (or not, your choice)
            return stringToSplit.Split(separator, count);
        }
    }
