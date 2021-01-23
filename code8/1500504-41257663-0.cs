    public static class ExtensionMethod
    {
        public static string ToFixedScale(this double value)
        {
            return Math.Truncate(value * 100) / 100).ToString("0.00");
        }
        public static string ToFixedScale(this double? value)
        {
            return value.HasValue ? ToFixedScale(value.Value) : null;
        }
    }
