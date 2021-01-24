    public class FixedJsonTextReader : JsonTextReader
    {
        public FixedJsonTextReader(TextReader reader) : base(reader) { }
        public override int? ReadAsInt32()
        {
            try
            {
                return base.ReadAsInt32();
            }
            catch
            {
                if (TokenType == JsonToken.PropertyName)
                    SetToken(JsonToken.None);
                throw;
            }
        }
    }
