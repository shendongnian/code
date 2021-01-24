    public static class UrlSlugExtension {
        public static string ToUrlSlug(this string value) {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;
            //this can still be improved to remove invalid URL characters
            var tokens = value.Trim().Split(new char[] {  ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join("-", tokens).ToLower();
        }
    }
