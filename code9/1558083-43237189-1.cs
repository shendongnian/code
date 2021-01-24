    public class CustomClassConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		//Implement if needed
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		var obj = (JObject)JObject.ReadFrom(reader);
    
    		var root = new Root();
    		root.Data = new Dictionary<string, List<CustomClass1>>();
    		
    		JObject value = (JObject)obj.GetValue("data");
    		foreach (JProperty prop1 in value.Properties())
    		{
    			var customObjects = new List<CustomClass1>();
    			foreach (JProperty prop2 in prop1.Values())
    			{
    				var customObject = new CustomClass1();
    				customObject.Date = DateTime.Parse(prop2.Name);
    				customObject.Values = new Dictionary<string, int>();
    				foreach (JProperty prop3 in prop2.Values())
    				{
    					customObject.Values.Add(prop3.Name, prop3.ToObject<int>());
    				}
    				customObjects.Add(customObject);
    			}
    			root.Data.Add(prop1.Name, customObjects);
    		}
    		
    		return root;
    	}
    
    	public override bool CanConvert(Type t)
    	{
    		return true;
    	}
    
    	public override bool CanRead
    	{
    		get { return true; }
    	}
    }
