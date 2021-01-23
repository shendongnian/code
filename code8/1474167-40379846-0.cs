    [DataContract]
    [KnownType( typeof( int ) )]
    [KnownType( typeof( double ) )]
    [KnownType( typeof( string ) )]
    [KnownType( typeof( Sample ) )]
    [KnownType( typeof( List<object> ) )]
    public class Sample
    {
        [DataMember]
        public object[] Values { get; set; }
    }
