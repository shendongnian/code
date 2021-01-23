    [ProtoBuf.ProtoContract(Name=@"MyBaseTypeProto")]
    [ProtoBuf.ProtoInclude(typeof(MyDerivedType), someFieldNumberUniqueInsideMyBaseType)]
    public partial class MyBaseType: ProtoBuf.IExtensible { ... }
    
    [ProtoBuf.ProtoContract(Name=@"MyDerivedTypeProto")] { ... }
    public partial class MyDerivedType : MyBaseType, ProtoBuf.IExtensible
    
    [ProtoBuf.ProtoContract(Name=@"MyMessageProto")]                                                                  
    public partial class MyMessage : ProtoBuf.IExtensible                                           
    {                                                                                               
        [ProtoBuf.ProtoMember(1, IsRequired = false, Name = @"MyList", DataFormat = ProtoBuf.DataFormat.Default)]
        [System.ComponentModel.DefaultValue(null)]                                                  
        public List<MyDerivedType> MyList;  
