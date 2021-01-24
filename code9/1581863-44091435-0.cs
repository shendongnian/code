    public static class PropertyGetter<T>
        {
            private static Dictionary<string, Func<T, string>> cache = new Dictionary<string, Func<T, string>>();
            public static Func<T, string> Get(string propertyName)
            {
                if (!cache.ContainsKey(propertyName))
                {
                    var param = Expression.Parameter(typeof(T));
                    Expression<Func<T, string>> exp = Expression.Lambda<Func<T, string>>(Expression.Property(param, propertyName),param);
                    cache[propertyName] = exp.Compile();
                }
                return cache[propertyName];
            }
            public static Predicate<object> GetPredicate(string propertyName, string pattern)
            {
                Func<T, string> getter = Get(propertyName);
                Regex regex = new Regex(pattern, RegexOptions.Compiled);
                return (obj) => regex.IsMatch(getter((T)obj));            }
        }
