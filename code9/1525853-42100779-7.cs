    public abstract class RequiredStringValueObject : ValueObject<string>
    {
        private string _value;
        protected string _fieldName;
        protected byte _maxLength;
        public string Value
        {
            get
            {
                return _value;
            }
            protected set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(_fieldName, _fieldName + " must be supplied.");
                }
                value = value.Trim();
                if (value.Length > _maxLength)
                {
                    throw new ArgumentOutOfRangeException(_fieldName, value, _fieldName + " can't be longer than " + _maxLength.ToString() + " characters.");
                }
                _value = value;
            }
        }
        protected RequiredStringValueObject(string fieldName, byte maxLength, string value)
        {
            _fieldName = fieldName;
            _maxLength = maxLength;
            Value = value;
        }
        public override IEnumerable<object> GetEqualityCheckAttributes()
        {
            return new List<object> { Value };
        }
    }
