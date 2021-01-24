    [CollectionDataContract(Namespace = "http://schemas.datacontract.org/2004/07/fogREST")] // All GraphicDetail child XML elements are to be in the indicated namespace
    public class GraphicDetailsCollection : List<GraphicDetail>
    {
    }
    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/fogREST")] // All data member child XML elements are to be in the indicated namespace
    public class GraphicDetail
    {
        [DataMember(IsRequired = false)]
        public string GraphicID;
        [DataMember(IsRequired = false)]
        public string PropName;
        [DataMember(IsRequired = false)]
        public string PropValue;
        [DataMember(IsRequired = false)]
        public string PropFileID;
        [DataMember(IsRequired = false)]
        public string PropFileDescription;
    }
