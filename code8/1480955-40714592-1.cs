    namespace V2
    {
        [ProtoInclude(10, typeof(MarketDataObject))]
        [ProtoContract]
        internal abstract class LowerStillBaseClass
        {
            [ProtoMember(1)]
            public string LowerStillBaseClassProperty { get; set; }
        }
        [ProtoContract]
        internal class MarketDataObject : LowerStillBaseClass
        {
            [ProtoMember(1)]
            public string Id { get; set; }
        }
    }
