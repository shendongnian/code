       public class MediaConverter : JsonCreationConverter<Message>
        {
            protected override Message Create(Type objectType, JObject jObject)
            {
                var msg = new Message();
                msg.Items = new List<Media>();
                foreach (var item in jObject["items"])
                {
                    Media media = new Media();
                    media.Id = item["media"]["id"].Value<string>();
                    msg.Items.Add(media);
                }
                return msg;
            }
        }
    
    
        public abstract class JsonCreationConverter<T> : JsonConverter
        {
    
            protected abstract T Create(Type objectType, JObject jObject);
    
            public override bool CanConvert(Type objectType)
            {
                return typeof(T).IsAssignableFrom(objectType);
            }
    
            public override object ReadJson(JsonReader reader,
                                            Type objectType,
                                             object existingValue,
                                             JsonSerializer serializer)
            {
                // Load JObject from stream
                JObject jObject = JObject.Load(reader);
    
                return target;
            }
    
            public override void WriteJson(JsonWriter writer,
                                           object value,
                                           JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
