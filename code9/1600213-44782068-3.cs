    public static class ExtensionMethods {
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> Dictionary, TKey Key, TValue Value) {
            if (Dictionary.ContainsKey(Key)) {
                Dictionary[Key] = Value;
            } else {
                Dictionary.Add(Key, Value);
            }
        }
    }
