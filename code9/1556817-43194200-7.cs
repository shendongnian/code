    [ProtoContract]
    public class MyData {
        [ProtoMember(1)]
        public Dictionary<int, SomeType> Items {get; } = new Dictionary<int, SomeType>();
        [ProtoMember(2)]
        public SomethingElse Whatever { get;set;}
    }
