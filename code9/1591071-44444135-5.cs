    class RootObjectConverter : CustomPropertiesConverter<RootObject>
    {
        const string ValuesName = "values";
        protected override IEnumerable<string> CustomProperties
        {
            get { return new[] { ValuesName }; }
        }
        protected override void DeserializeCustomProperties(Dictionary<string, object> customDictionary, RootObject obj, JavaScriptSerializer serializer)
        {
            object itemCost;
            if (customDictionary.TryGetValue(ValuesName, out itemCost) && itemCost != null)
                obj.Values = serializer.FromSingleOrArray<float>(itemCost).ToArray();
        }
        protected override void SerializeCustomProperties(RootObject obj, Dictionary<string, object> dict, JavaScriptSerializer serializer)
        {
            obj.Values.ToSingleOrArray(dict, ValuesName);
        }
    }
    public abstract class CustomPropertiesConverter<T> : JavaScriptConverter
    {
        protected abstract IEnumerable<string> CustomProperties { get; }
        protected abstract void DeserializeCustomProperties(Dictionary<string, object> customDictionary, T obj, JavaScriptSerializer serializer);
        protected abstract void SerializeCustomProperties(T obj, Dictionary<string, object> dict, JavaScriptSerializer serializer);
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            // Detach custom properties
            var customDictionary = new Dictionary<string, object>();
            foreach (var key in CustomProperties)
            {
                object value;
                if (dictionary.TryRemoveInvariant(key, out value))
                    customDictionary.Add(key, value);
            }
            // Deserialize and populate all members other than "values"
            var obj = new JavaScriptSerializer().ConvertToType<T>(dictionary);
            // Populate custom properties
            DeserializeCustomProperties(customDictionary, obj, serializer);
            return obj;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            // Generate a default serialization.  Is there an easier way to do this?
            var defaultSerializer = new JavaScriptSerializer();
            var dict = defaultSerializer.Deserialize<Dictionary<string, object>>(defaultSerializer.Serialize(obj));
            // Remove default serializations of custom properties, if present
            foreach (var key in CustomProperties)
            {
                dict.RemoveInvariant(key);
            }
            // Add custom properties
            SerializeCustomProperties((T)obj, dict, serializer);
            return dict;
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(T) }; }
        }
    }
    public static class JavaScriptSerializerObjectExtensions
    {
        public static void ReplaceInvariant<T>(this IDictionary<string, T> dictionary, string key, T value)
        {
            RemoveInvariant(dictionary, key);
            dictionary.Add(key, value);
        }
        public static bool TryRemoveInvariant<T>(this IDictionary<string, T> dictionary, string key, out T value)
        {
            if (dictionary == null)
                throw new ArgumentNullException();
            var keys = dictionary.Keys.Where(k => string.Equals(k, key, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (keys.Length == 0)
            {
                value = default(T);
                return false;
            }
            else if (keys.Length == 1)
            {
                value = dictionary[keys[0]];
                dictionary.Remove(keys[0]);
                return true;
            }
            else
            {
                throw new ArgumentException(string.Format("Duplicate keys found: {0}", String.Join(",", keys)));
            }
        }
        public static void RemoveInvariant<T>(this IDictionary<string, T> dictionary, string key)
        {
            if (dictionary == null)
                throw new ArgumentNullException();
            foreach (var actualKey in dictionary.Keys.Where(k => string.Equals(k, key, StringComparison.OrdinalIgnoreCase)).ToArray())
                dictionary.Remove(actualKey);
        }
        public static void ToSingleOrArray<T>(this ICollection<T> list, IDictionary<string, object> dictionary, string key)
        {
            if (dictionary == null)
                throw new ArgumentNullException();
            if (list == null || list.Count == 0)
                dictionary.RemoveInvariant(key);
            else if (list.Count == 1)
                dictionary.ReplaceInvariant(key, list.First());
            else
                dictionary.ReplaceInvariant(key, list.ToArray());
        }
        public static List<T> FromSingleOrArray<T>(this JavaScriptSerializer serializer, object value)
        {
            if (value == null)
                return null;
            if (value.IsJsonArray())
            {
                return value.AsJsonArray().Select(i => serializer.ConvertToType<T>(i)).ToList();
            }
            else
            {
                return new List<T> { serializer.ConvertToType<T>(value) };
            }
        }
        public static bool IsJsonArray(this object obj)
        {
            if (obj is string || obj is IDictionary)
                return false;
            return obj is IEnumerable;
        }
        public static IEnumerable<object> AsJsonArray(this object obj)
        {
            return (obj as IEnumerable).Cast<object>();
        }
    }
