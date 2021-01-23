        public class SteeringWheelJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ISteeringWheel).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jo = new JObject();
            Type type = value.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.CanRead)
                {
                    var propVal = prop.GetValue(value, null);
                    if (prop.Name == "Identifier")
                    {
                        // Iterate over all properties of the identifier, but don't add the identifier object itself 
                        // to the serialized result.
                        Type identifierType = propVal.GetType();
                        foreach (var identifierProp in identifierType.GetProperties())
                        {
                            var identifierPropVal = identifierProp.GetValue(propVal, null);
                            jo.Add(identifierProp.Name, identifierPropVal != null ? JToken.FromObject(identifierPropVal, serializer) : null);
                        }
                    }
                    else
                    {
                        // Add the property to the serialized result
                        jo.Add(prop.Name, propVal != null ? JToken.FromObject(propVal, serializer) : null);
                    }
                }
            }
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanRead
        {
            get { return false; }
        }
    }
