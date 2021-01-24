    public class EnumStringValueAttribute : Attribute
    {
        public EnumStringValueAttribute(string rawValue)
        {
            this.RawValue = rawValue;
        }
        internal string RawValue { get; set; }
    }
