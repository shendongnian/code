    public class RootObjectConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var result = new RootObject();
    
            if (dictionary.TryGetValue(nameof(RootObject.items), out object obj) && obj is Dictionary<string, object> items)
            {
                result.items = new List<ItemObject>(items.Count);
    
                foreach (var item in items)
                {
                    result.items.Add(serializer.ConvertToType<ItemObject>(item.Value));
                }
            }
            else
            {
                return null; // or throw
            }
    
            return result;
        }
    
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var result = new Dictionary<string, object>();
    
            if (obj is RootObject rootObject)
            {
                var nestedDict = new Dictionary<string, object>();
    
                foreach (var item in rootObject.items)
                {
                    nestedDict[item.id] = item;
                }
    
                result[nameof(RootObject.items)] = nestedDict;
            }
    
            return result;
        }
    
        public override IEnumerable<Type> SupportedTypes => new List<Type> { typeof(RootObject) }.AsReadOnly();
    }
