    public static class ValueMapper {
        private static Dictionary<Type, Func<object, object>> _rules = new Dictionary<Type, Func<object, object>>();
        public static void CreateMap<TFrom, TTo>(Func<TFrom, TTo> valueFunc) {
            _rules.Add(typeof(TFrom), c => valueFunc((TFrom)c));
        }
        public static TTo Map<TTo>(object instance) {
            if (_rules.ContainsKey(instance.GetType()))
                return (TTo) _rules[instance.GetType()](instance);
            // throw here if necessary 
            return default(TTo);
        }
    }
