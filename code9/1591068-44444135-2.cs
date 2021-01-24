    class RootObjectConverter : JavaScriptConverter
    {
        const string ValuesName = "values";
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            // Detach "values"
            object itemCost = dictionary.DetachInvariant(ValuesName);
            // Deserialize and populate all members other than "values"
            var myObj = new JavaScriptSerializer().ConvertToType<RootObject>(dictionary);
            // Manually deserialize "values".
            if (itemCost != null)
            {
                myObj.Values = serializer.FromSingleOrArray<float>(itemCost).ToArray();
            }
            return myObj;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            // Generate a default serialization.  Is there an easier way to do this?
            var defaultSerializer = new JavaScriptSerializer();
            var dict = defaultSerializer.Deserialize<Dictionary<string, object>>(defaultSerializer.Serialize(obj));
            // Replace the "values" key.
            var rootObject = (RootObject)obj;
            rootObject.Values.ToSingleOrArray(dict, ValuesName);
            return dict;
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(RootObject) }; }
        }
    }
    public static class JavaScriptSerializerObjectExtensions
    {
        public static void ReplaceInvariant<T>(this IDictionary<string, T> dictionary, string key, T value)
        {
            RemoveInvariant(dictionary, key);
            dictionary.Add(key, value);
        }
        public static T DetachInvariant<T>(this IDictionary<string, T> dictionary, string key)
        {
            if (dictionary == null)
                throw new ArgumentNullException();
            if (dictionary == null)
                throw new ArgumentNullException();
            var keys = dictionary.Keys.Where(k => String.Equals(k, key, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (keys.Length == 0)
                return default(T);
            else if (keys.Length == 1)
            {
                var value = dictionary[keys[0]];
                dictionary.Remove(keys[0]);
                return value;
            }
            else
            {
                throw new ArgumentException(string.Format("Duplicate keys found: {0}", key));
            }
        }
        
        public static void RemoveInvariant<T>(this IDictionary<string, T> dictionary, string key)
        {
            if (dictionary == null)
                throw new ArgumentNullException();
            foreach (var actualKey in dictionary.Keys.Where(k => String.Equals(k, key, StringComparison.OrdinalIgnoreCase)).ToArray())
                dictionary.Remove(actualKey);
        }
        public static void ToSingleOrArray<T>(this ICollection<T> list, IDictionary<string, object> dictionary, string key)
        {
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
