    public class MyTestClass
    {
		[JsonProperty(ItemConverterType = typeof(SubtypeConverter<object, string []>))]
        public ArrayList Items { get; private set; }
        public MyTestClass()
        {
            this.Items = new ArrayList();
        }
    }
	public class SubtypeConverter<TBase, TDerived> : JsonConverter where TDerived : TBase
	{
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
			return serializer.Deserialize(reader, typeof(TDerived));
        }
        public override bool CanConvert(Type objectType)
        {
			return typeof(TBase) == objectType;   // DO NOT USE typeof(TBase).IsAssignableFrom(objectType);
        }
	}
