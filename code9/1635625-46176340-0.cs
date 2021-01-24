     public class MyHashSetSerializer : SerializerBase<HashSet<EngineType>>
    {
        private readonly IBsonSerializer _serializer =
            BsonSerializer.LookupSerializer(typeof(EngineType));
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, HashSet<EngineType> value)
        {
            var set = (HashSet<EngineType>)value;
            context.Writer.WriteStartDocument();
            BsonSerializationArgs enumSerializer = new BsonSerializationArgs(typeof(EngineType), false, false);
            int i = 0;
            foreach (var element in set)
            {
                context.Writer.WriteName($"[{i}]");
                context.Writer.WriteString(element.ToString());
            }
            context.Writer.WriteEndDocument();
        }
        public override HashSet<EngineType> Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var set = new HashSet<EngineType>();
            context.Reader.ReadStartDocument();
            while (context.Reader.ReadBsonType() != 0)
            {
                context.Reader.SkipName();
                var element =
                    (EngineType)_serializer.Deserialize(context, args);              
                set.Add(element);
            }
            context.Reader.ReadEndDocument();
            return set;
        }
    }
