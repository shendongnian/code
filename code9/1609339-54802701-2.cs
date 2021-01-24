    public static class StringExtensions
    {
        public static string Interpolate(this string self, object interpolationContext)
        {
            var placeholders = Regex.Matches(self, @"\{(.*?)\}");
            foreach (Match placeholder in placeholders)
            {
                var placeholderValue = placeholder.Value;
                var placeholderPropertyName = placeholderValue.Replace("{", "").Replace("}", "");
                var value = GetPropertyValue(interpolationContext, placeholderPropertyName)?.ToString() ?? "";
                self = self.Replace(placeholderValue, value);
            }
            return self;
        }
        public static object GetPropertyValue(object src, string propName)
        {
            if (src == null) throw new ArgumentException("Value cannot be null.", nameof(src));
            if (propName == null) throw new ArgumentException("Value cannot be null.", nameof(propName));
            if (propName.Contains("."))
            {
                var temp = propName.Split(new char[] {'.'}, 2);
                return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
            }
            var prop = src.GetType().GetProperty(propName);
            return prop != null ? prop.GetValue(src, null) : null;
        }
    }
