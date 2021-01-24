    public class DynamicJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
        {        
            JToken token = JToken.Load(reader);
    
            if (token == null || token.Type != JTokenType.Array)
            {
                return null;
            }
    
            List<NameValueJsonItem> parsedJson = token.ToObject<List<NameValueJsonItem>>();
            
            ExpandoObject result = new ExpandoObject();
            
            foreach (NameValueJsonItem item in parsedJson)
            {
                if (!String.IsNullOrEmpty(item.Name))
                {
                    (result as IDictionary<string, object>)[item.Name] = item.Value;
                }
            }
    
            return result;
        }
    
        public override void WriteJson(JsonWriter writer, object value, 
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
