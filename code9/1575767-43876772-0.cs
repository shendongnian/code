    public class XmlAttributeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(XmlAttribute[]);
        } 
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var dict = serializer.Deserialize<Dictionary<string, string>>(reader);
            var doc = new XmlDocument();
            return dict.Select(p => { var a = doc.CreateAttribute(p.Key); a.Value = p.Value; return a; }).ToArray();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // TODO: determine how to represent XmlAttribute values with non-empty NamespaceURI - or throw an exception.
            var attributes = (IEnumerable<XmlAttribute>)value;
            var dict = attributes.ToDictionary(a => a.Name, a => a.Value);
            serializer.Serialize(writer, dict);
        }
    }
    class ScoresConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Scores);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var attributes = (XmlAttribute[])new XmlAttributeArrayConverter().ReadJson(reader, typeof(XmlAttribute[]), null, serializer);
            return new Scores { AnyAttr = attributes };
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var scores = (Scores)value;
            if (scores.AnyAttr == null)
                writer.WriteNull();
            else
            {
                new XmlAttributeArrayConverter().WriteJson(writer, scores.AnyAttr, serializer);
            }
        }
    }
