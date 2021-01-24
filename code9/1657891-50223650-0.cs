    static class NormalizeString
    {
        public static string TrimAndNullIfWhiteSpace(this string text) =>
           string.IsNullOrWhiteSpace(text)
           ? null
           : text.Trim();
    }
