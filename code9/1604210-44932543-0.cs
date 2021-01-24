    public class SomeMeaningfulName
    {
        private SomeMeaningfulName(string value)
        {
            Value = value;
        }
        public string Value { get; }
        public static SomeMeaningfulName String1 = new SomeMeaningfulName("First String");
        public static SomeMeaningfulName String2 = new SomeMeaningfulName("Second String");
    }
