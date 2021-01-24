    public static class DynamicExtensions
    {
        public static Object TryGetProperty(ExpandoObject obj, String name)
        {
            return name.Split('.')
                       .Aggregate((Object)obj, (o, s) => o != null
                                                          ? TryGetPropertyInternal(o, s)
                                                          : null);
        }
        private static Object TryGetPropertyInternal(Object obj, String name)
        {
            var dict = obj as IDictionary<String, Object>;
            return (dict?.ContainsKey(name) ?? false) ? dict[name] : null;
        }
    }
