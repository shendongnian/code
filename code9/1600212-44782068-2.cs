    public static void AddOrUpdate(this IDictionary<string, string> Dictionary, string Key, string Value) {
        if (Dictionary.ContainsKey(Key)) { //<-- NOTE ContainsKey
            Dictionary[Key] = Value;
        } else {
            Dictionary.Add(Key, Value);
        }
    }
