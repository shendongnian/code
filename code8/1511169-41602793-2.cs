    public class NullableIntAsStringSerializer : SerializerBase<int?>
    {
        public override void Serialize(
            BsonSerializationContext context, BsonSerializationArgs args, int? value)
        {
            context.Writer.WriteString(value.HasValue ? value.ToString() : "null");
        }
        public override int? Deserialize(
            BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var str = context.Reader.ReadString();
            return str == "null" ? (int?)null : Int32.Parse(str);
        }
    }
