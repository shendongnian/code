    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
    
    using (JsonWriter writer = new JsonTextWriter(sw))
    {
    	writer.Formatting = Formatting.Indented;
    
    	writer.WriteStartObject(); // {
    	writer.WritePropertyName("Product"); // "Product:"
    	writer.WriteStartArray(); // [
    	writer.WriteRaw(JsonConvert.SerializeObject(pr)); // your object
    	writer.WriteEnd(); // ]
    	writer.WriteEndObject(); //}
    }
    
    var result = sb.ToString();
