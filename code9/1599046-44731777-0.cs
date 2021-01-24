     public class TitleConverter : JsonConverter
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JArray jObject = JArray.Load(reader);
    
                Title title = JsonConvert.DeserializeObject<Title>(jObject[0].ToString());
                    return title;
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override bool CanConvert(Type objectType)
            {
                if (objectType.Name == "Title")
                    return true;
                return false;
            }
        }
