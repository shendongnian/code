    public class CustomUserMapper : ICustomBsonTypeMapper
    {
        public bool TryMapToBsonValue(object value, out BsonValue bsonValue)
        {
            bsonValue = ((User)value).ToBsonDocument();
            return true;
        }
    }
