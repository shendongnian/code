    [BsonSerializer(typeof(MyGuidSerializer))]
    public class MyGuidSerializer : IBsonSerializer<Guid>
    {
        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return Guid.Parse(BsonSerializer.Deserialize<string>(context.Reader));
        }
        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Guid value)
        {
            BsonSerializer.Serialize(context.Writer, value.ToString());
        }
        Guid IBsonSerializer<Guid>.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return Guid.Parse(BsonSerializer.Deserialize<string>(context.Reader));
        }
        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            BsonSerializer.Serialize(context.Writer, value.ToString());
        }
        public Type ValueType
        {
            get { return typeof(Guid); }
        }
    }
