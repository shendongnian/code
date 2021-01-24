    class Converter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var searchResultToken = jObject.GetValue("searchresult");
            var searchResult = new SearchResult()
            {
                Relevances = new List<RelevanceWrapper>()
            };
            foreach (JProperty prop in searchResultToken)
            {
                if (prop.Name == "summary")
                {
                    searchResult.Summary = prop.Value.ToObject<Summary>();
                }
                else
                {
                    searchResult.Relevances.Add(prop.Value.ToObject<RelevanceWrapper>());
                }
            }
            
            return searchResult;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
