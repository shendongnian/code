    public static class TypeReflectionHelper
    {
        public static Dictionary<Type, PropertyInfo[]> PropertyInfoCache;
        static TypeReflectionHelper()
        {
            PropertyInfoCache = new Dictionary<Type, PropertyInfo[]>();
        }
        public static PropertyInfo[] GetTypeProperties(this Type type)
        {
            if (!PropertyInfoCache.ContainsKey(type))
            {
                PropertyInfoCache[type] = type.GetProperties();
            }
            return PropertyInfoCache[type];
        }
    }
