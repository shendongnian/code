    public class StructuredListConverter<T> : JsonConverter
    {
        const string typeName = "type";
        const string structureName = "structure";
        const string listName = "list";
        public override bool CanConvert(Type objectType)
        {
            if (typeof(ICollection<T>).IsAssignableFrom(objectType))
                return false;
            // This converter is only implemented for read/write collections.  So no arrays.
            if (objectType.IsArray)
                return false; 
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var collection = existingValue as ICollection<T> ?? (ICollection<T>) serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            var root = JObject.Load(reader);
            var structure = root[structureName] == null ? null : root[structureName].ToObject<string []>();
            if (structure == null)
                throw new JsonSerializationException("structure not found.");
            var listToken = root[listName];
            if (listToken == null || listToken.Type == JTokenType.Null)
                return collection;
            var list = listToken as JArray;
            if (list == null)
                throw new JsonSerializationException("list was not an array.");
            if (list == null || list.Count == 0)
                return collection;
            foreach (var item in list)
            {
                if (item == null || item.Type == JTokenType.Null)
                    collection.Add(default(T));
                else if (item.Type != JTokenType.Array)
                    throw new JsonSerializationException(string.Format("Item was not an array: {0}", item));
                else
                    collection.Add(new JObject(item.Zip(structure, (i, n) => new JProperty(n, i))).ToObject<T>());
            }
            return collection;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(typeof(T)) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException(string.Format("Type {0} is not mapped to a JSON object.", typeof(T)));
            var collection = (ICollection<T>)value;
            writer.WriteStartObject();
            // Write item type
            writer.WritePropertyName(typeName);
            serializer.Serialize(writer, typeof(T));
            // Write structure (property names)
            var structure = contract.Properties.Where(p => p.Readable && !p.Ignored).Select(p => p.PropertyName).ToList();
            writer.WritePropertyName(structureName);
            serializer.Serialize(writer, structure);
            // Write array of array of values
            var query = collection
                .Select(i => i == null ? null : contract.Properties.Where(p => p.Readable && !p.Ignored).Select(p => p.ValueProvider.GetValue(i)));
            writer.WritePropertyName(listName);
            serializer.Serialize(writer, query);
            writer.WriteEndObject();
        }
    }
