    public static class Null
    {
        public static bool IsNull<T>(T obj) => !Data<T>.HasValue(obj);
        private static class Data<T>
        {
            public static readonly Func<T, bool> HasValue = InitHasValue();
            private static Func<T, bool> InitHasValue()
            {
                var type = typeof(T);
                if (!type.IsValueType)
                    return obj => obj != null;
                if (type.IsGenericType &&
                    type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var value = Expression.Parameter(type, "value");
                    var getter = type.GetProperty("HasValue").GetMethod;
                    var call = Expression.Call(value, getter);
                    var lambda = Expression.Lambda<Func<T, bool>>(call, value);
                    return lambda.Compile();
                }
                return obj => true;
            }
        }
    }
