    public static class Extensions {
        public static IQueryable<T> WherePropStringContains<T>(this IQueryable<T> queryable, String name, String value) {
            IEnumerable<String> propertyNames = name.Split('.');
            return queryable.Where(x => ObjectChainHasProperties(x, propertyNames, value));
        }
        private static bool ObjectChainHasProperties(Object obj, IEnumerable<String> propertyNames, String value) {
            IEnumerator<String> enumerator = propertyNames.GetEnumerator();
            while (obj != null && enumerator.MoveNext()) {
                obj = obj.GetType().GetProperties()
                    .Where(p => p.Name == enumerator.Current)
                    .FirstOrDefault()?
                    .GetValue(obj);
            }
            return (obj as String) == value;
        }
    }
