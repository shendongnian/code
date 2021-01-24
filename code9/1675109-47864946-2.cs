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
                JObject obj = new JObject(list.Select(dm =>
                {
                    JToken val;
                    if (dm.DataMapperProperty != null)
                        val = JToken.FromObject(dm.DataMapperProperty, serializer);
                    else 
                        val = JToken.FromObject(dm.SubDataMappers, serializer);
                    return new JProperty(dm.Name, val);
                }));
                obj.WriteTo(writer);
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
                     .Select(jp => 
                     {
                         DataMapper mapper = new DataMapper { Name = jp.Name };
                         JToken val = jp.Value;
                         if (val["data-type"] != null)
                             mapper.DataMapperProperty = jp.Value.ToObject<DataMapperProperty>(serializer);
                         else
                             mapper.SubDataMappers = jp.Value.ToObject<List<DataMapper>>(serializer);
                         return mapper;
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
