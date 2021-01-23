    public static class EnumerableExtensions {
            public static IEnumerable<T> OmitProperties<T>(this IEnumerable<T> enumerable, params string[] propertyNames) {
                PropertyInfo[] propertiesToOmit = typeof(T).GetProperties()
                    .Where(p => propertyNames.Contains(p.Name))
                    .ToArray();
    
                foreach (var item in enumerable) {
                    foreach (var property in propertiesToOmit) {
                        property.SetValue(item, Activator.CreateInstance(property.GetType()));
                    }
    
                    yield return item;
                }
            }
        }
