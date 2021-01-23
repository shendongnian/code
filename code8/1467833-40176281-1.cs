    public class AllowedValuesAttribute : ValidationAttribute
    {
        private readonly ICollection<object> _validValues;
        private readonly Type _type;
        public AllowedValuesAttribute(Type type, object[] validValues)
        {
            _type = type;
            _validValues = validValues.Where(v => v != null && v.GetType() == type).ToList();
        }
        public override bool IsValid(object value)
        {
            return value.GetType() == _type && _validValues.Contains(value);
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format("Value for '{0}' is not an allowed value", name);
        }
    }
