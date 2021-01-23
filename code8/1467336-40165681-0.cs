    public class MyContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            var result = base.CreateContract(objectType);
            var primContract = result as JsonPrimitiveContract;
            if (primContract != null 
				&& (primContract.CreatedType == typeof(DateTime) || primContract.CreatedType == typeof(DateTime?))
				&& primContract.Converter == null
			   )
            {
				//Console.WriteLine("Adding {0} callbacks for {1}", primContract.ToString(), objectType.ToString());
				var converter = new MyIsoDateTimeConverter();
                converter.OnDeserializingCallbacks.Add((o, context) =>
                {
					Console.WriteLine("Deserializing " + o);
                });
                converter.OnDeserializedCallbacks.Add((o, context) =>
                {
					Console.WriteLine("Deserialized " + o);
                });
				primContract.Converter = converter;
            }
            return result;
        }
    }
	class MyIsoDateTimeConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
	{
        private List<SerializationCallback> _onDeserializingCallbacks;
        private List<SerializationCallback> _onDeserializedCallbacks;
		
        public IList<SerializationCallback> OnDeserializingCallbacks
        {
            get
            {
                if (_onDeserializingCallbacks == null)
                {
                    Interlocked.CompareExchange(ref _onDeserializingCallbacks, new List<SerializationCallback>(), null);
                }
                return _onDeserializingCallbacks;
            }
        }
		public IList<SerializationCallback> OnDeserializedCallbacks
        {
            get
            {
                if (_onDeserializedCallbacks == null)
                {
                    Interlocked.CompareExchange(ref _onDeserializedCallbacks, new List<SerializationCallback>(), null);
                }
                return _onDeserializedCallbacks;
            }
        }
		
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var value = base.ReadJson(reader, objectType, existingValue, serializer);
			if (value != null && value is DateTime)
			{
				if (_onDeserializingCallbacks != null)
				{
					foreach (var callback in _onDeserializingCallbacks)
						callback(value, serializer.Context);
				}
				if (_onDeserializedCallbacks != null)
				{
					foreach (var callback in _onDeserializedCallbacks)
						callback(value, serializer.Context);
				}
			}
			
			return value;
		}
	}	
