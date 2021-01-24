    class CustomJsonConverter : JsonConverter
        {
            
            public override bool CanConvert(Type objectType)
            {
                bool result = typeof(Dictionary<string,string>).IsAssignableFrom(objectType);
                return result;
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                JObject jo = new JObject();
    
                foreach (var item in (Dictionary<string,string>)value)
                {
                    if (item.Key.Contains("."))
                    {
                        if (jo.Property(item.Key.Split('.')[0].ToString()) == null)
                        {
                            jo.Add(item.Key.Split('.')[0],
                                   new JObject() { { item.Key.Split('.')[1], item.Value } });
                        }
                        else
                        {
                            var result = jo.Property(item.Key.Split('.')[0].ToString()).Value as JObject; ;
                            result.Add(item.Key.Split('.')[1], item.Value);
                        }
                    }
                    else
                    {
                        jo.Add(item.Key, item.Value);
                    }
                }
                jo.WriteTo(writer);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
