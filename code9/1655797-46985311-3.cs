    public static class Extensions
    {
        public static DateTime AddMonths(this DateTime startingValue, double months)
        {
            // Cast to an int to avoid recursing back to this method
            var wholeMonths = (int)Math.Floor(months);
            var partialMonth = months - wholeMonths;
            var result = startingValue.AddMonths(wholeMonths);
            return result.AddDays(Math.Floor(
                result.AddMonths(1).Subtract(result).TotalDays * partialMonth));
        }
    }
