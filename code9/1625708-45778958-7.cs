    public class ObjectListToSequentialPropertyArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType.GetListType();
        }
        static bool ShouldSkip(JsonProperty property)
        {
            return property.Ignored || !property.Readable || !property.Writable;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            var itemType = objectType.GetListType();
            if (itemType == null)
                throw new ArgumentException(objectType.ToString());
            var itemContract = serializer.ContractResolver.ResolveContract(itemType) as JsonObjectContract;
            if (itemContract == null)
                throw new JsonSerializationException("invalid type " + objectType.FullName);
            var list = (IList)value;
            var propertyList = list
                .OfType<Object>()
                .Where(i => i != null) // Or should we throw an exception?
                .SelectMany(i => itemContract.Properties.Where(p => !ShouldSkip(p)).Select(p => p.ValueProvider.GetValue(i)));
            serializer.Serialize(writer, propertyList);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var itemType = objectType.GetListType();
            if (itemType == null)
                throw new ArgumentException(objectType.ToString());
            if (reader.TokenType == JsonToken.Null)
                return null;
            var array = JArray.Load(reader);
            var listContract = serializer.ContractResolver.ResolveContract(objectType) as JsonArrayContract;
            var itemContract = serializer.ContractResolver.ResolveContract(itemType) as JsonObjectContract;
            if (itemContract == null || listContract == null)
                throw new JsonSerializationException("invalid type " + objectType.FullName);
            var list = existingValue as IList ?? (IList)listContract.DefaultCreator();
            var properties = itemContract.Properties.Where(p => !ShouldSkip(p)).ToArray();
            for (int startIndex = 0; startIndex < array.Count; startIndex += properties.Length)
            {
                var item = itemContract.DefaultCreator();
                for (int iProperty = 0; iProperty < properties.Length; iProperty++)
                {
                    if (startIndex + iProperty >= array.Count)
                        break;
                    var propertyValue = array[startIndex + iProperty].ToObject(properties[iProperty].PropertyType, serializer);
                    properties[iProperty].ValueProvider.SetValue(item, propertyValue);
                }
                list.Add(item);
            }
            return list;
        }
    }
    public static class TypeExtensions
    {
        public static Type GetListType(this Type type)
        {
            while (type != null)
            {
                if (type.IsGenericType)
                {
                    var genType = type.GetGenericTypeDefinition();
                    if (genType == typeof(List<>))
                        return type.GetGenericArguments()[0];
                }
                type = type.BaseType;
            }
            return null;
        }
    }
