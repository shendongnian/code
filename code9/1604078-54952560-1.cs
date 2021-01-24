    [DataContract]
    public class PatchSomethingRequest
    {
        [DataMember(Name = "prop1")]
        public RQFieldPatch<EnumTypeHere> Prop1 { get; set; }
        [DataMember(Name = "prop2")]
        public RQFieldPatch<ComplexTypeContractHere> Prop2 { get; set; }
        [DataMember(Name = "prop3")]
        public RQFieldPatch<string> Prop3 { get; set; }
        [DataMember(Name = "prop4")]
        public RQFieldPatch<int> Prop4 { get; set; }
        [DataMember(Name = "prop5")]
        public RQFieldPatch<int?> Prop5 { get; set; }
    }
