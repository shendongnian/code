    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var x = (value as Expando);
        writer.WriteStartObject();
        foreach (var item in x.GetProperties(true))
        {
            writer.WritePropertyName(item.Key);
            serializer.Serialize(writer,item.Value);
            // Do not close the object here also.
        }
        writer.WriteEndObject();
    }
