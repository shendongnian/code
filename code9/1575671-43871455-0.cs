    [ProtoContract]
    public class ClassA
    {
        [ProtoMember(1)
        int Version { get { return 1; } set {} }
        [ProtoMember(2)]
        int VarA;
        [ProtoMember(3)]
        int VarB;
        [ProtoMember(4)]
        string VarC;
    
    
        public ClassA()
        {
            //[...]
        }
    
        public void MethodX()
        {
            //[...]
        }
    }
    
    [ProtoContract]
    public class ClassA_0
    {
        [ProtoMember(1)
        int Version { get { return 2; } set {} }
        [ProtoMember(2)] // this is the same - compatible, keep tag
        int VarA;
        [ProtoMember(5)] // not the same: new tag
        string VarB;
    
    
        public ClassA()
        {
            //[...]
        }
    
        public void MethodX()
        {
            //[...]
        }
    }
