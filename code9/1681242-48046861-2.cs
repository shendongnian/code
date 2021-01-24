    public class MyViewModelConverter : JsonConverter {
    
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(MyViewModel);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jObject = JObject.Load(reader);//<-- Note the use of Load() instead of Parse()
            var images = jObject.Property("images").Value<JObject>(); ;
            var model = new MyViewModel {
                Images = new ImagesViewModel {
                    TotalCount = images.Property("totalCount").Value<int>(),
                    ListImages = images.Properties().Skip(1).ToDictionary(p => p.Name, p => p.Value<ImageViewModel>())
                }
            };
            return model;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
