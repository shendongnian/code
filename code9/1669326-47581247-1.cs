    public class PolymorphicArrayToObjectConverter<TObject> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(TObject).IsAssignableFrom(objectType);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        static JsonObjectContract FindContract(JObject obj, IEnumerable<Type> derivedTypes, JsonSerializer serializer)
        {
            List<JsonObjectContract> bestContracts = new List<JsonObjectContract>();
            foreach (var type in derivedTypes)
            {
                if (type.IsAbstract)
                    continue;
                var contract = serializer.ContractResolver.ResolveContract(type) as JsonObjectContract;
                if (contract == null)
                    continue;
                if (obj.Properties().Select(p => p.Name).Any(n => contract.Properties.GetClosestMatchProperty(n) == null))
                    continue;
                if (bestContracts.Count == 0 || bestContracts[0].Properties.Count > contract.Properties.Count)
                {
                    bestContracts.Clear();
                    bestContracts.Add(contract);
                }
                else if (contract.Properties.Count == bestContracts[0].Properties.Count)
                {
                    bestContracts.Add(contract);
                }
            }
            return bestContracts.Single();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            else if (reader.TokenType != JsonToken.StartArray)
                throw new InvalidOperationException("JSON token is not an array at path: " + reader.Path);
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(objectType);
            existingValue = existingValue ?? contract.DefaultCreator();
            var lookup = contract
                .Properties
                .Select(p => new { Property = p, PropertyContract = serializer.ContractResolver.ResolveContract(p.PropertyType) as JsonArrayContract })
                .Where(i => i.PropertyContract != null)
                .ToDictionary(i => i.PropertyContract.CollectionItemType);
            var types = lookup.Select(i => i.Key).ToList();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Comment:
                        break;
                    case JsonToken.EndArray:
                        return existingValue;
                    default:
                        {
                            var itemObj = JObject.Load(reader);
                            var itemContract = FindContract(itemObj, types, serializer);
                            if (itemContract == null)
                                continue;
                            var item = serializer.Deserialize(itemObj.CreateReader(), itemContract.UnderlyingType);
                            var propertyData = lookup[itemContract.UnderlyingType];
                            var collection = propertyData.Property.ValueProvider.GetValue(existingValue);
                            if (collection == null)
                            {
                                collection = propertyData.PropertyContract.DefaultCreator();
                                propertyData.Property.ValueProvider.SetValue(existingValue, collection);
                            }
                            collection.GetType().GetMethod("Add").Invoke(collection, new [] { item });
                        }
                        break;
                }
            }
            // Should not come here.
            throw new JsonSerializationException("Unclosed array at path: " + reader.Path);
        }
    }
