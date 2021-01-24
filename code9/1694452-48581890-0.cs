    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Guid value)
        {
            var data = new BsonBinaryData(value);
            context.Writer.WriteBinaryData(data);
        }
    public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return BsonSerializer.Deserialize<Guid>(context.Reader);
        }
