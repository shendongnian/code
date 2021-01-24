    class AppraiserCalendarDtoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(AppraiserCalendarDto));
        }
        public override object ReadJson(JsonReader reader, Type objectType, 
                                        object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var dto = new AppraiserCalendarDto();
            dto.Links = jo["links"].ToObject<List<AppraiserCalendarDto.Link>>();
            var dict = new Dictionary<DateTime, AppraiserCalendarDto.Record>();
            dto.Records = dict;
            foreach (JProperty prop in jo.Properties().Where(p => p.Name != "links"))
            {
                var date = DateTime.Parse(prop.Name);
                var record = prop.Value["regular"].ToObject<AppraiserCalendarDto.Record>();
                dict.Add(date, record);
            }
            return dto;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, 
                                       object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
