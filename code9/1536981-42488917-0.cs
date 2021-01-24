    public abstract class Streaming
    {
        public virtual void SerializeBinaryCore(BinaryStreamWriter writer)
        {
            // put the logic from your original SerializeBinary method here...
        }
    
        public virtual bool DeserializeFromBinaryCore(BinaryStreamReader reader, out string errorMessage)
        {
            // put the logic from your original DeserializeFromBinary method here...
        }
    
        public abstract void SerializeBinary(BinaryStreamWriter writer);
    
        public abstract bool DeserializeFromBinary(BinaryStreamReader reader, out string errorMessage);
    }
