    public class SomeClass
    {
        [DataMember]
        public string Var1 { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Var2 { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public object Var3 { get; set; }
    }
