        public static IEnumerable<string> ToListOfStrings<T>(this IEnumerable<T> items, string sep)
        {
            var properties = typeof(T).GetInstanceProperties();
            yield return properties.Select(p => p.Name).CreateRow(sep);
            foreach (var item in items)
            {
                yield return properties.GetValues(item, sep).CreateRow(sep);
            }
        }
        private static string CreateRow(this IEnumerable<string> values, string separator)
        {
            return values.JoinStrings(separator) + System.Environment.NewLine;
        }
        private static string JoinStrings(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values);
        }
        public static PropertyInfo[] GetInstanceProperties(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
        private static IEnumerable<string> GetValues(this IEnumerable<PropertyInfo> properties, object obj, string separator)
        {
            return properties.Select(p => GetString(p.GetValue(obj, null), separator));
        }
        public static string GetString(object obj, string separator)
        {
            var type = obj.GetType();
            if (type.IsPrimitive || type.IsEnum || type == typeof(string))
                return obj.ToString();
            var result = obj.GetType().GetInstanceProperties()
                            .GetValues(obj, separator)
                            .JoinStrings(separator);
            return string.Format("({0})", result);
        }
