    string json ="{ 'Teaser': [{ 'id': '...', 'type': 'category', 'url': 'https:...', },{ 'id': '...', 'type': 'brand', 'url': 'https:...', 'videoCount': 1, },{ 'id': '...', 'type': 'video', 'url': 'https:...', 'headline': '...', }]}";
    		
    var list = JsonConvert.DeserializeObject<StartPage>(json);
    public class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
        {
            protected override JsonConverter ResolveContractConverter(Type objectType)
            {
                if (typeof(Teaser).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                    return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
                return base.ResolveContractConverter(objectType);
            }
        }
    public class BaseConverter : JsonConverter
        {
            static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };
    
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(Teaser));
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject jo = JObject.Load(reader);
                switch (jo["type"].Value<string>())
                {
                    case "video":
                        return JsonConvert.DeserializeObject<Video>(jo.ToString(), SpecifiedSubclassConversion);
                    case "brand":
                        return JsonConvert.DeserializeObject<Brand>(jo.ToString(), SpecifiedSubclassConversion);
                    default:
                        throw new Exception();
                }
                throw new NotImplementedException();
            }
    
            public override bool CanWrite
            {
                get { return false; }
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException(); // won't be called because CanWrite returns false
            }
        }
