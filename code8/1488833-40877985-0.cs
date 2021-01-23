    public class LowerCasePropertyNameJsonReader : JsonTextReader
    {
        public LowerCasePropertyNameJsonReader(TextReader textReader)
            : base(textReader)
        {
        }
        public override object Value
        {
            get
            {
                if (TokenType == JsonToken.PropertyName)
                    return ((string)base.Value).ToLower();
                return base.Value;
            }
        }
    }
