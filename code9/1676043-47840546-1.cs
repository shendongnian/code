    public static class ValueMapper {
        private static Dictionary<Type, Func<object, object>> _rules = new Dictionary<Type, Func<object, object>>();
        public static void CreateMap<TFrom, TTo>(Func<TFrom, TTo> valueFunc) {
            _rules.Add(typeof(TFrom), c => valueFunc((TFrom)c));
        }
        public static object Map<T>(T instance) {
            if (_rules.ContainsKey(typeof(T)))
                return _rules[typeof(T)](instance);
            // or throw here, or return null, depending on what you need
            return instance;
        }
    }
