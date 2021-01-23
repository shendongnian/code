    private static string GenerateStr<T>(IEnumerable<T> list, string propName)
        {
            var propertyInfo = typeof(T).GetProperty(propName);
            return string.Concat(list.Select(o => propertyInfo.GetValue(o, null)));
        }
