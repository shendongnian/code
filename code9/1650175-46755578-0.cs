     public class MyCustomConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(Root).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    JArray rootToken = JArray.Load(reader);
    
                    if (rootToken[0] != null && rootToken[1] != null)
                    {
                        var root = new Root(rootToken[0].Value<int>(), this.readItems(rootToken[1]));
                        return root;
                    }
                }
    
                return existingValue;
            }
    
            private IList<Item> readItems(JToken items)
            {
                var itemList = new List<Item>();
                if (items.Type == JTokenType.Array)
                {
                    foreach(var item in items.Children())
                    {
                        if (item.Type == JTokenType.Array && item.Count() == 4)
                        {
                            itemList.Add(new Item(
                                item[0].Value<int>(),
                                item[1].Value<long>(),
                                item[2].Value<decimal>(),
                                item[3].Value<decimal>()));
                        }
                    }
                }
    
                return itemList;
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
