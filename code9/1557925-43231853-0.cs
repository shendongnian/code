    public static class StringExt
    {
        public static bool EqualsAnyOf(this string value, params string[] targets)
        {
            return targets.Any(target => target.Equals(value));
        }
    }
