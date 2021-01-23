    public static class ExtensionMethod
    {
        public static string ToFixedScale(this double? value)
        {
            return value.HasValue ? (Math.Truncate(value.Value * 100) / 100).ToString("0.00") : null;
        }
        public static string ToFixedScale(this double value)
        {
            return ToFixedScale((double?)value);
        }
    }
