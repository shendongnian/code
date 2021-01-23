    public class DateTimeJsonConverter : JsonConverter
    {	
    	public override void WriteJson(JsonWriter jsonWriter, object inputObject,JsonSerializer jsonSerializer)
    	{
    		// Typecast the input object
    		var dateTimeObject = inputObject as DateTime?;
    		
    		// Set the properties of the Json Writer
    		jsonWriter.Formatting = Newtonsoft.Json.Formatting.Indented;
    		
    		if(dateTimeObject == DateTime.MinValue)
    			jsonWriter.WriteValue((DateTime?)null);
    		else
    			jsonWriter.WriteValue(dateTimeObject);
    	}
    
    	
    	public override object ReadJson(JsonReader reader,
    		Type objectType,
    		object existingValue,
    		JsonSerializer serializer)
    	{
    		DateTime? readValue = reader.ReadAsDateTime();
    		
    		return (readValue == null) ? DateTime.MinValue : readValue;		
    		
    	}
    
    	
    	public override bool CanConvert(Type objectType)
    	{
    		return typeof(DateTime?).IsAssignableFrom(objectType);
    	}
    }
