    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var properties = value.GetType().GetProperties();
        writer.WriteStartObject();
        foreach (var property in properties)
        {
            // Write the property name
            writer.WritePropertyName(property.Name);
            // Get the value of the property and get the type
            serializer.Serialize(writer, property.GetValue(value, null).GetType());
        }
        writer.WriteEndObject();
    }
