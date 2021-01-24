    public class UserTypeEnumConverter : StringEnumConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UserType);
        }
    
        public override object ReadJson(JsonReader reader, 
                                        Type objectType, 
                                        object existingValue, 
                                        JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                var isNullable = (Nullable.GetUnderlyingType(objectType) != null);
                if (!isNullable)
                {
                    throw new JsonSerializationException();
                }
                return null;
            }
    
            var token = JToken.Load(reader);
            var value = token.ToString();
            if (string.Equals(value, "chump", StringComparison.OrdinalIgnoreCase))
            {
                return UserType.Citizen;
            }
            else
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }               
        }
    }
