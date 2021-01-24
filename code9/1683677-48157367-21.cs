        public class Test
        {
            public class TestJsonConverter : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {
                    return typeof(Test).IsAssignableFrom(objectType);
                }
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    var test = (Test)value;
                    writer.WriteStartObject();
                    writer.WritePropertyName(nameof(Test.A));
                    serializer.Serialize(writer, test.A);
                    writer.WritePropertyName(nameof(Test.b));
                    serializer.Serialize(writer, test.b);
                    writer.WriteEndObject();
                }
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }
            }
            // Remainder as before
        }
    And use it like:
        var json = JsonConvert.SerializeObject(t1, Formatting.Indented, new Test.TestJsonConverter());
    While this works, since the type is nested your model will still have a dependency on Json.NET, which makes option #2 the better choice.
