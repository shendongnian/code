    public class ChangeTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // This is important, we can use this converter for ChangeType only
            return typeof(ChangeType).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = JToken.Load(reader);
            // Types match, it can be deserialized without problems.
            if (value.Type == JTokenType.Object)
                return JsonConvert.DeserializeObject(value.ToString(), objectType);
            else
            {
                // Convert to ChangeType and set the value, if not null:
                var t = (ChangeType)Activator.CreateInstance(objectType);
                if (value.Type != JTokenType.Null)
                    t.Text = value.ToString();
                return t;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var d = value.GetType();
            if (typeof(ChangeType).IsAssignableFrom(d))
            {
                var changeObject = (ChangeType)value;
                // e.g. GenericChangeType<int>
                if (value.GetType().IsGenericType)
                {
                    try
                    {
                        // type - int
                        var type = value.GetType().GetGenericArguments()[0];
                        var c = Convert.ChangeType(changeObject.Text, type);
                        // write the int value
                        writer.WriteValue(c);
                    }
                    catch
                    {
                        // Ignore the exception, just write null.
                        writer.WriteNull();
                    }
                }
                else
                {
                    // ChangeType object. Write the inner string (like xmlText value)
                    writer.WriteValue(changeObject.Text);
                }
                // Done writing.
                return;
            }
            // Another object that is derived from ChangeType.
            // Do not add the current converter here because this will result in a loop.
            var s = new JsonSerializer
            {
                NullValueHandling = serializer.NullValueHandling,
                DefaultValueHandling = serializer.DefaultValueHandling,
                ContractResolver = serializer.ContractResolver
            };
            JToken.FromObject(value, s).WriteTo(writer);
        }
    }
