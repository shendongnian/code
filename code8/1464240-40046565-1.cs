    public static class DoubleExtensions
    {
        public static double RoundDown(this double value, int numDigits)
        {
            double factoral = Math.Pow(10, numDigits);
            return Math.Truncate(value * factoral) / factoral;
        }
    }
