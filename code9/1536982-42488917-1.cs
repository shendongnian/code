    public class Asset : Streaming
    {
        public override void SerializeBinary(BinaryStreamWriter writer)
        {
            SerializeBinaryCore(writer);
        }
        public override void DeserializeFromBinary(BinaryStreamReader reader, out string errorMessage)
        {
            var result = DeserializeFromBinaryCore(reader, out errorMessage);
            // put the rest of your Asset deserialization logic here...
        }
    }
