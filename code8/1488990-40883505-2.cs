    // Generated from: Question40863857_1.proto
    namespace transit_realtime
    {
      [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FeedHeader")]
      public partial class FeedHeader : global::ProtoBuf.IExtensible
      {
        public FeedHeader() {}
    
        private string _gtfs_realtime_version;
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"gtfs_realtime_version", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string gtfs_realtime_version
        {
          get { return _gtfs_realtime_version; }
          set { _gtfs_realtime_version = value; }
        }
        private transit_realtime.FeedHeader.Incrementality _incrementality = transit_realtime.FeedHeader.Incrementality.FULL_DATASET;
        [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"incrementality", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        [global::System.ComponentModel.DefaultValue(transit_realtime.FeedHeader.Incrementality.FULL_DATASET)]
        public transit_realtime.FeedHeader.Incrementality incrementality
        {
          get { return _incrementality; }
          set { _incrementality = value; }
        }
        private ulong _timestamp = default(ulong);
        [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"timestamp", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        [global::System.ComponentModel.DefaultValue(default(ulong))]
        public ulong timestamp
        {
          get { return _timestamp; }
          set { _timestamp = value; }
        }
        private NyctFeedHeader _nyct_feed_header = NyctFeedHeader.Value0;
        [global::ProtoBuf.ProtoMember(1001, IsRequired = false, Name=@"nyct_feed_header", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
        [global::System.ComponentModel.DefaultValue(NyctFeedHeader.Value0)]
        public NyctFeedHeader nyct_feed_header
        {
          get { return _nyct_feed_header; }
          set { _nyct_feed_header = value; }
        }
        [global::ProtoBuf.ProtoContract(Name=@"Incrementality")]
        public enum Incrementality
        {
    
          [global::ProtoBuf.ProtoEnum(Name=@"FULL_DATASET", Value=0)]
          FULL_DATASET = 0,
    
          [global::ProtoBuf.ProtoEnum(Name=@"DIFFERENTIAL", Value=1)]
          DIFFERENTIAL = 1
        }
    
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
          { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
      }
    
    }
    // Generated from: Question40863857_2.proto
    // Note: requires additional types generated from: Question40863857_1.proto
    namespace Question40863857_2
    {
        [global::ProtoBuf.ProtoContract(Name=@"NyctFeedHeader")]
        public enum NyctFeedHeader
        {
    
          [global::ProtoBuf.ProtoEnum(Name=@"Value0", Value=0)]
          Value0 = 0,
    
          [global::ProtoBuf.ProtoEnum(Name=@"Value1", Value=1)]
          Value1 = 1
        }
    
    }
