    public static class ToDictionaryExtensionMethod
    {
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            return source.ToDictionary<object>();
        }
    }
