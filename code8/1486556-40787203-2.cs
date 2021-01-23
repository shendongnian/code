        public static IEnumerable<string> ToListOfStrings<T>(this List<T> items, string sep)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            yield return properties.Select(p => p.Name).CreateRow(sep);
            foreach (var item in items)
            {
                yield return properties.Select(p => GetString(p.GetValue(item, null))).CreateRow(sep);
            }
        }
        private static string CreateRow(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values) + System.Environment.NewLine;
        }
        public static string GetString(object obj)
        {
            //custom logic to create string from values
            return obj.ToString();
        }
