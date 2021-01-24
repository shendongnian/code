    public class StringEnumContractResolver : DefaultContractResolver
    {
        readonly StringEnumConverter converter;
        public StringEnumContractResolver() : this(true, false) { }
        public StringEnumContractResolver(bool allowIntegerValue, bool camelCaseText)
        {
            this.converter = new StringEnumConverter { AllowIntegerValues = allowIntegerValue, CamelCaseText = camelCaseText };
        }
        protected override JsonPrimitiveContract CreatePrimitiveContract(Type objectType)
        {
            var contract = base.CreatePrimitiveContract(objectType);
            var type = Nullable.GetUnderlyingType(contract.UnderlyingType) ?? contract.UnderlyingType;
            if (type.IsEnum && contract.Converter == null)
                contract.Converter = converter;
            return contract;
        }
    }
