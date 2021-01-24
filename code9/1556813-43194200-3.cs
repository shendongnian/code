    [ProtoContract]
    public class MyData {
        [ProtoMember(1)]
        public Hashtable Items {get; } = new Hashtable();
        [ProtoMember(2)]
        public ISometing Whatever { get;set;}
    }
