    public static class ValueMapper {
        private static Dictionary<string, Func<object, object>> _rules = new Dictionary<string, Func<object, object>>();
        public static void CreateMap<T>(string ruleName, Func<T, object> valueFunc) {
            _rules.Add(ruleName, c => valueFunc((T) c));
        }
    }
