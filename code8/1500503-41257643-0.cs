    public static class ExtensionMethods
    {
        public static string ToFixedScale(this double? value)
        {
            return value.HasValue ? value.Value.ToFixedScale() : null;
        }
        public static string ToFixedScale(this double value)
        {
            return (Math.Truncate(value.Value * 100) / 100).ToString("0.00");
        }
    }
