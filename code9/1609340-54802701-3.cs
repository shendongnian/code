    public static class StringExtensions
    {
        public static string Interpolate(this string self, object interpolationContext)
        {
            var placeholders = Regex.Matches(self, @"\{(.*?)\}");
            foreach (Match placeholder in placeholders)
            {
                var placeholderValue = placeholder.Value;
                var placeholderPropertyName = placeholderValue.Replace("{", "").Replace("}", "");
                var property = interpolationContext.GetType().GetProperty(placeholderPropertyName);
                var value = property?.GetValue(interpolationContext)?.ToString() ?? "";
                self = self.Replace(placeholderValue, value);
            }
            return self;
        }
    }
