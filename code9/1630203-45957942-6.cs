    public class GithubPayloadConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(GithubPayload);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            dynamic data = JObject.Load(reader);
            var model = new GithubPayload {
                Action = data.action,
                Name = data.pull_request.title
            };
            return model;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
