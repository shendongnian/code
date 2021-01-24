        [DataContract(Name = "Root", Namespace = "http://www.MyNamespace.com")]
        class RootObjectDTO
        {
            [DataMember]
            public NestedObjectDTO NestedObject { get; set; }
        }
        [DataContract(Name = "Nested", Namespace = "http://www.MyNamespace.com")]
        class NestedObjectDTO
        {
            [DataMember]
            public string PublicData { get; set; }
        }
    If automapper is not available on silverlight, you can use `DataContractSerializer` itself to do the mapping, since the contract names and namespaces are identical.  I.e. - serialize the real root object to an XML string (or to an `XDocument` as shown below), deserialize the intermediate XML to the DTO root, then serialize out the DTO.
