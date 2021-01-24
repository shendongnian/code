     public class FirstName : RequiredStringValueObject
    {
        private FirstName(string value) : base(nameof(FirstName),30, value) { }
        public static FirstName Create(string value)
        {
            return new FirstName(value);
        }
    }
