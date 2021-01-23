    public class CustomerConverter : JsonConverter 
    {
         public override bool CanConvert(Type objectType)
         {
            return objectType == typeof (Customer);
         }
         public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
          {
                var eobj = (Customer) value;
                var temp = new Dictionary<string, object>(eobj);
                temp.Add("Id", eobj.Id);
                serializer.Serialize(writer, temp);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                var temp = serializer.Deserialize<Dictionary<string, object>>(reader);
                var eobj = new Customer();
                foreach (var key in temp.Keys)
                {
                    if (key == "Id")
                        eobj.Id = (Guid) temp[key];
                    else
                        eobj.Add(key, temp[key]);
                }
                return eobj;
            }
        }
