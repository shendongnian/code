    public class DescriptionSerializer : ClassSerializer<Description>
    {
        private const byte Version = 1;
        public override int StoreToStream(Stream stream, KeyDescription item)
        {
            if (item == null)
            {
                return WriteVersionNull(stream);
            }
            var count = stream.WriteIntVariableLength(Version);
            count += stream.WriteString(item.StringProperty);
            count += stream.WriteBytes(item.BytesPropery);
            count += stream.WriteIntVariableLength(item.IntegerProperty);
            return count;
        }
        public override Description CreateFromStream(Stream stream)
        {
            var version = stream.ReadIntVariableLength();
            if (version == VersionNull) return null;
            if (version != Version)
            {
                throw new InvalidDataException(
                    string.Format("The stream version '{0}' is incorrect. The data cannot be deserialized. ", version));
            }
            var stringProperty = stream.ReadString();
            var bytesProperty = stream.ReadBytes();
            var integerProperty = stream.ReadIntVariableLength();
            return new Description(
                stringProperty, 
                bytesProperty, 
                integerProperty);
        }
    }
