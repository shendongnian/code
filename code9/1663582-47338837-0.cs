    public static class DoubleStaticExtension
    {
        public static string ToString(this double value, string format, bool roundToHalf)
        {
            return (Math.Round(value * 20, MidpointRounding.AwayFromZero) / 20).ToString(format);
        }
    }
