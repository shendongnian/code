    public class ConcurrentBagConverter : ConcurrentBagConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetConcurrentBagItemType() != null;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            try
            {
                var itemType = objectType.GetConcurrentBagItemType();
                var method = GetType().GetMethod("ReadJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                var genericMethod = method.MakeGenericMethod(new[] { objectType, itemType });
                return genericMethod.Invoke(this, new object[] { reader, objectType, itemType, existingValue, serializer });
            }
            catch (TargetInvocationException ex)
            {
                // Wrap the TargetInvocationException in a JsonSerializationException
                throw new JsonSerializationException("Failed to deserialize " + objectType, ex);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            try
            {
                var itemType = objectType.GetConcurrentBagItemType();
                var method = GetType().GetMethod("WriteJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                var genericMethod = method.MakeGenericMethod(new[] { objectType, itemType });
                genericMethod.Invoke(this, new object[] { writer, value, serializer });
            }
            catch (TargetInvocationException ex)
            {
                // Wrap the TargetInvocationException in a JsonSerializationException
                throw new JsonSerializationException("Failed to serialize " + objectType, ex);
            }
        }
    }
    public class ConcurrentBagConverter<TItem> : ConcurrentBagConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ConcurrentBagConverter<TItem>).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return ReadJsonGeneric<ConcurrentBag<TItem>, TItem>(reader, objectType, typeof(TItem), existingValue, serializer);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WriteJsonGeneric<ConcurrentBag<TItem>, TItem>(writer, value, serializer);
        }
    }
    // https://stackoverflow.com/questions/42836648/json-net-deserialize-complex-object-with-concurrent-collection-in-composition
    public abstract class ConcurrentBagConverterBase : JsonConverter
    {
        protected TConcurrentBag ReadJsonGeneric<TConcurrentBag, TItem>(JsonReader reader, Type collectionType, Type itemType, object existingValue, JsonSerializer serializer)
            where TConcurrentBag : ConcurrentBag<TItem>
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartArray)
                throw new JsonSerializationException(string.Format("Expected {0}, encountered {1} at path {2}", JsonToken.StartArray, reader.TokenType, reader.Path));
            var collection = existingValue as TConcurrentBag ?? (TConcurrentBag)serializer.ContractResolver.ResolveContract(collectionType).DefaultCreator();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Comment:
                        break;
                    case JsonToken.EndArray:
                        return collection;
                    default:
                        collection.Add((TItem)serializer.Deserialize(reader, itemType));
                        break;
                }
            }
            // Should not come here.
            throw new JsonSerializationException("Unclosed array at path: " + reader.Path);
        }
        protected void WriteJsonGeneric<TConcurrentBag, TItem>(JsonWriter writer, object value, JsonSerializer serializer)
            where TConcurrentBag : ConcurrentBag<TItem>
        {
            // Snapshot the bag as an array and serialize the array.
            var array = ((TConcurrentBag)value).ToArray();
            serializer.Serialize(writer, array);
        }
    }
    internal static class TypeExtensions
    {
        public static Type GetConcurrentBagItemType(this Type objectType)
        {
            while (objectType != null)
            {
                if (objectType.IsGenericType
                    && objectType.GetGenericTypeDefinition() == typeof(ConcurrentBag<>))
                {
                    return objectType.GetGenericArguments()[0];
                }
                objectType = objectType.BaseType;
            }
            return null;
        }
    }
    public class ConcurrentBagContractResolver : DefaultContractResolver
    {
        protected override JsonArrayContract CreateArrayContract(Type objectType)
        {
            var contract = base.CreateArrayContract(objectType);
            var concurrentItemType = objectType.GetConcurrentBagItemType();
            if (concurrentItemType != null)
            {
                if (contract.Converter == null)
                    contract.Converter = (JsonConverter)Activator.CreateInstance(typeof(ConcurrentBagConverter<>).MakeGenericType(new[] { concurrentItemType }));
            }
            return contract;
        }
    }
