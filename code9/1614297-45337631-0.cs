    public class DomainTypeToBeHandldedAsString
    {
        public string Value { get; set; }
        public override string ToString() => Value;
        public static DomainTypeToBeHandldedAsString Parse(string s)
            => new DomainTypeToBeHandldedAsString { Value = s };
    }
