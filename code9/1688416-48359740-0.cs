    [ProtoContract]
    public class Wrapper
    {
        [ProtoMember(1)]
        public string Value { get; set; }
    }
    [ProtoContract]
    public class TestResult
    {
        [ProtoMember(1, DataFormat = DataFormat.Group)]
        public CollectionWrapper First { get; set; }
    }
    [ProtoContract]
    public class CollectionWrapper
    {
        [ProtoMember(1, DataFormat = DataFormat.Group)]
        public List<Wrapper> Collection { get; set; } = new List<Wrapper>();
    }
