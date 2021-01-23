       writer.WriteStartObject();
       foreach (var item in list)
        {
            
            writer.WritePropertyName(item.Key);
            writer.WriteValue(item.Value);
            
        }
        writer.WriteEndObject();
        writer.WriteEndArray();
