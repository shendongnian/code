    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
    using (JsonWriter writer = new JsonTextWriter(sw))
    {
        writer.Formatting = Formatting.Indented;
        while (dataReader.Read())
        {
            writer.WriteStartObject();
            for (int i = 0; i < dataReader.fieldCount; ++i)
            {
                writer.WritePropertyName(dataReader.GetName(i));
                writer.WriteValue(dataReader.GetValue(i).ToString());
            }
            writer.WriteEndObject();
        }
    }
    fileWriter.Write(sb.ToString());
