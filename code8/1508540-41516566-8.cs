    public class SongsResponseJsonConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		var result = new SongsResponse();
    		
    		var obj = JObject.Load(reader);
    		result.version = obj["version"].Value<string>();
    		result.date = obj["date"].Value<DateTime>();
    		result.count = obj["count"].Value<int>();
    		result.songs =
    			obj
    			.Properties()
    			.Where(x => !(new string[] { "version", "date", "count" }.Contains(x.Name)))
    			.Select(x => new { Id = int.Parse(x.Name), Song = x })
    			.OrderBy(x => x.Id)
    			.Select(x => x.Song.Value.ToObject<Song>())
    			.ToList();
    		return result;
    	}
    
    	public override bool CanRead
    	{
    		get { return true; }
    	}
    
    	public override bool CanWrite
    	{
    		get { return false; }
    	}
    
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof(SongsResponse);
    	}
    }
