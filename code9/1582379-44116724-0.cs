    class StringEnumExceptFooConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is Foo || value is Foo?)
            {
                writer.WriteValue(value);
            }
            else
            {
                base.WriteJson(writer, value, serializer);
            }
        }
    }
  
