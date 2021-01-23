    class CollectionConverter<TCollection, TItem> : JsonConverter where TCollection : new()
    {
        private string ListPropertyName { get; set; }
        public CollectionConverter(string listPropertyName)
        {
            ListPropertyName = listPropertyName;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TCollection);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<TItem> list = (List<TItem>)typeof(TCollection).GetProperty(ListPropertyName).GetValue(value, null);
            JArray array = JArray.FromObject(list);
            array.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            List<TItem> list = array.ToObject<List<TItem>>();
            TCollection collection = new TCollection();
            typeof(TCollection).GetProperty(ListPropertyName).SetValue(collection, list);
            return collection;
        }
    }
