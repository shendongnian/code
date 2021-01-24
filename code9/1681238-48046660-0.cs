        class ImagesViewModelConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(ImagesViewModel);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                assertToken(JsonToken.StartObject);
                var obj = new ImagesViewModel()
                {
                    ListImages = new Dictionary<string, ImageViewModel>()
                };
                while (reader.Read() && reader.TokenType != JsonToken.EndObject)
                {
                    assertToken(JsonToken.PropertyName);
                    var propName = (string)reader.Value;
                    if (propName.Equals(nameof(ImagesViewModel.TotalCount), StringComparison.InvariantCultureIgnoreCase))
                    {
                        reader.Read();
                        assertToken(JsonToken.Integer);
                        obj.TotalCount = (int)((Int64)reader.Value);
                        continue;
                    }
                    reader.Read();
                    var image = serializer.Deserialize<ImageViewModel>(reader); // you can still use normal json deseralization inside a converter
                    obj.ListImages.Add(propName, image);
                }
                
                return obj;
                void assertToken(JsonToken token)
                {
                    if (reader.TokenType != token)
                        throw new Exception(); // might wanna add detailed errors
                }
            }
            
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException(); // implement if needed
            }
        }
