    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    public class CardListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IEnumerable<Card>).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var list = existingValue as ICollection<Card> ?? new List<Card>();
            var obj = JObject.Load(reader);
            foreach (var property in obj.Properties())
            {
                list.Add(new Card { IndexName = property.Name, CardImage = new Image { Src = (string)property.Value } });
            }
            return list;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var collection = (IEnumerable<Card>)value;
            writer.WriteStartObject();
            foreach (var item in collection)
            {
                writer.WritePropertyName(item.IndexName);
                writer.WriteValue(item.CardImage == null ? null : item.CardImage.Src);
            }
            writer.WriteEndObject();
        }
    }
