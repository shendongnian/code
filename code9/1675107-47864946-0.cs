    public class DataMapperListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<DataMapper>);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<DataMapper> list = (List<DataMapper>)value;
            if (list.Any(dm => dm.DataMapperProperty != null))
            {
                serializer.Serialize(writer,
                    list.ToDictionary(dm => dm.Name, dm => dm.DataMapperProperty));
            }
            else
            {
                serializer.Serialize(writer,
                    list.Select(dm => new Dictionary<string, List<DataMapper>>
                    {
                        { dm.Name, dm.SubDataMappers }
                    }));
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                return token.Children<JProperty>()
                     .Select(jp => new DataMapper
                     {
                         Name = jp.Name,
                         DataMapperProperty = jp.Value.ToObject<DataMapperProperty>(serializer)
                     })
                     .ToList();
            }
            else if (token.Type == JTokenType.Array)
            {
                return token.Children<JObject>()
                    .SelectMany(jo => jo.Properties())
                    .Select(jp => new DataMapper
                    {
                        Name = jp.Name,
                        SubDataMappers = jp.Value.ToObject<List<DataMapper>>(serializer)
                    })
                    .ToList();
            }
            else
            {
                throw new JsonException("Unexpected token type: " + token.Type.ToString());
            }
        }
    }
