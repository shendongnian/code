    public class EnvelopeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, 
            JsonSerializer serializer)
        {
    		throw new NotImplementedException();
    	}
    
        public override object ReadJson(JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
        {
    		var envelope = JObject.Load(reader);
            var type = envelope["Type"].ToString();
            var message = JsonConvert.DeserializeObject<Message>(
                envelope["InnerMessage"].ToString());
    		return new Envelope
    		{
    			Type = type,
    			InnerMessage = message
    		};
    	}
    
        public override bool CanRead
        {
            get { return true; }
        }
    
        public override bool CanConvert(Type objectType)
        {
    		return true;
    	}
    }
