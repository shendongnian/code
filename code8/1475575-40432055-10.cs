    public class ArrayMergeConverter<T> : ArrayMergeConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsArray && objectType.GetArrayRank() == 1 && objectType.GetElementType() == typeof(T);
        }
    }
    public class ArrayMergeConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!objectType.IsArray)
                throw new JsonSerializationException(string.Format("Non-array type {0} not supported.", objectType));
            var contract = (JsonArrayContract)serializer.ContractResolver.ResolveContract(objectType);
            if (contract.IsMultidimensionalArray)
                throw new JsonSerializationException("Multidimensional arrays not supported.");
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartArray)
                throw new JsonSerializationException(string.Format("Invalid start token: {0}", reader.TokenType));
            var itemType = contract.CollectionItemType;
            var existingList = existingValue as IList;
            IList list = new List<object>();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Comment:
                        break;
                    case JsonToken.Null:
                        list.Add(null);
                        break;
                    case JsonToken.EndArray:
                        var array = Array.CreateInstance(itemType, list.Count);
                        list.CopyTo(array, 0);
                        return array;
                    default:
                        // Add item to list
                        var existingItem = existingList != null && list.Count < existingList.Count ? existingList[list.Count] : null;
                        if (existingItem == null)
                        {
                            existingItem = serializer.Deserialize(reader, itemType);
                        }
                        else
                        {
                            serializer.Populate(reader, existingItem);
                        }
                        list.Add(existingItem);
                        break;
                }
            }
            // Should not come here.
            throw new JsonSerializationException("Unclosed array at path: " + reader.Path);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
