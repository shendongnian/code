        public CustomJsonReader(TextReader reader) : base(reader) { }
        public override object Value
        {
            get
            {
                if (TokenType != JsonToken.PropertyName)
                {
                    return base.Value;
                }
                var propertyName = base.Value.ToString();
                if (propertyName.StartsWith("$"))
                {
                    return $"@{propertyName.Substring(1)}";
                }
                else
                {
                    return base.Value;
                }
            }
        }
    }
