    public class CollectionInterfaceConverterForModels<TInterface> : JsonConverter
    {
        private readonly TypeNameSerializationBinder Binder;
        public CollectionInterfaceConverterForModels()
        {
            Binder = new TypeNameSerializationBinder("Cartable.Models.{0}, Cartable");
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IList<TInterface>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var currentBinder = serializer.Binder;
            var currentTypeNameHandling = serializer.TypeNameHandling;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Binder = Binder;
            IList<TInterface> items = serializer.Deserialize<List<TInterface>>(reader).ToList();
            serializer.TypeNameHandling = currentTypeNameHandling;
            serializer.Binder = currentBinder;
            return items;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //The reason store these, is to leave system unchanged, in case it customized on general section by another programmer
            var currentBinder = serializer.Binder;
            var currentTypeNameHandling = serializer.TypeNameHandling;
            serializer.TypeNameHandling=TypeNameHandling.Auto;
            serializer.Binder = Binder;
            serializer.Serialize(writer, value, typeof(List<TInterface>));
            serializer.TypeNameHandling = currentTypeNameHandling;
            serializer.Binder = currentBinder;
        }
    }
