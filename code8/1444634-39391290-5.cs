    public struct OuterStruct
    {
        public OuterStruct(InnerStruct x)
        {
            X = x;
        }
        public InnerStruct X { get; }
    }
    public struct InnerStruct
    {
        public int A;
        public int B;
    }
