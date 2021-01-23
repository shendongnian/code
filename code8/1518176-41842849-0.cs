    static class Extensions
    {
        public static int GetIntValue(this string orig)
        {
            var trimmed = orig?.GetTrimmedValue();
            return trimmed == null ? 0 : int.Parse(trimmed);
        }
        public static string GetTrimmedValue(this string orig)
        {
            var trimmed = orig?.Trim();
            if (string.IsNullOrEmpty(trimmed))
                return null;
            else
                return trimmed;
        }
    }
