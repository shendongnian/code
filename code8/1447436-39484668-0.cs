    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
    
    using (JsonWriter writer = new JsonTextWriter(sw))
    {
        writer.WriteStartObject();
    	foreach(var item in excelBoList)
    	{
    	    writer.WritePropertyName(item.InterfaceColId);
    		writer.WriteValue(item.IOValue);
    	}
        writer.WriteEnd();
        writer.WriteEndObject();
    }
    
    var result = sb.ToString();
