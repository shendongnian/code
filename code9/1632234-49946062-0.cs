        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(BaseClass))
            {
                JObject item = JObject.Load(reader);
                if (item["isClass2"].Value<bool>())
                {
                    return item.ToObject<ChildClass2>(serializer);
                }
                else
                {
                    return item.ToObject<ChildClass1>(serializer);
                }
            }
            else
            {
                serializer.ContractResolver.ResolveContract(objectType).Converter = null;
                return serializer.Deserialize(reader, objectType);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
