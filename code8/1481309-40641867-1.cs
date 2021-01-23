	public class MainStuff : IMainStuff
	{ 
		[JsonProperty(ItemConverterType = typeof(TypeConverter<ISubStuff, SubStuff>))]
		public Dictionary<string, ISubStuff> SubStuff
		{ 
			get; 
			set; 
		} 
	}
	public class TypeConverter<T, TSerialized> : CustomCreationConverter<T> 
		where TSerialized : T, new()
	{
        public override T Create(Type objectType)
        {
			return new TSerialized();
        }
	}
