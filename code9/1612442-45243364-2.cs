    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JsonSerializer ser2 = new JsonSerializer();
        foreach (PropertyInfo prop in typeof(JsonSerializer).GetProperties()
                .Where(p => p.Name != nameof(JsonSerializer.Converters)))
        {
            prop.SetValue(ser2, prop.GetValue(serializer));
        }
        JObject.FromObject(value, ser2).WriteTo(writer);
    }
