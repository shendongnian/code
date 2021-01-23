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
            if (reader.TokenType == JsonToken.Null)
                return null;
            var existingList = existingValue as IList;
            if (reader.TokenType != JsonToken.StartArray)
                throw new JsonSerializationException(string.Format("Invalid start token: {0}", reader.TokenType));
            var contract = (JsonArrayContract)serializer.ContractResolver.ResolveContract(objectType);
            if (contract.IsMultidimensionalArray)
                throw new JsonSerializationException(string.Format("Multidimensional arrays not supported."));
            if (contract.ItemConverter != null)
                throw new JsonSerializationException(string.Format("contract.ItemConverter not supported."));
            var itemType = contract.CollectionItemType;
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
                        var existingItem = list.Count < existingList.Count ? existingList[list.Count] : null;
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
