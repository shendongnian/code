    public class UserGroupJsonConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(UserGroup) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            return new UserGroup((string)reader.Value);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            writer.WriteValue(((UserGroup)value).Code);
        }
    }
