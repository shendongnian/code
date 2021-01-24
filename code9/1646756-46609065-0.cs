    public static class Enum<T>
    {
        public static IEnumerable<T> GetOrderedValues()
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new InvalidOperationException();
            return from f in type.GetFields(BindingFlags.Static | BindingFlags.Public)
                   orderby f.GetCustomAttribute<EnumOrderAttribute>()?.Order ?? Int32.MaxValue
                   select (T)f.GetValue(obj: null);
        }
    }
