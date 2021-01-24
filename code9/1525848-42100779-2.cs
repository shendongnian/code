     public class FirstName : RequiredStringValueObject
    {
        private FirstName(string value)
        {
            _fieldName = "FirstName";
            _maxLength = 30;
            Value = value;
        }
        public static FirstName Create(string value)
        {
            return new FirstName(value);
        }
        public override IEnumerable<object> GetEqualityCheckAttributes()
        {
            return new List<object> { Value };
        }
    }
