    using ProtoBuf;
    using ProtoBuf.Meta;
    
    public class DomainTypeToBeHandldedAsString
    {
        public string Value { get; set; }
        public override string ToString() => Value;
        public static DomainTypeToBeHandldedAsString Parse(string s)
            => new DomainTypeToBeHandldedAsString { Value = s };
    }
    [ProtoContract]
    public class Bar
    {
        [ProtoMember(1)]
        public DomainTypeToBeHandldedAsString A { get; set; }
    }
    class Program
    {
        static void Main()
        {
            RuntimeTypeModel.Default.AllowParseableTypes = true;
            var obj = new Bar { A = new DomainTypeToBeHandldedAsString { Value = "abcdef" } };
            var clone = Serializer.DeepClone(obj);
            System.Console.WriteLine(clone.A.Value);
        }
    }
