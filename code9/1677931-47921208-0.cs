    public struct myStruct
    {
        public int A {get;set;}
        public int B {get;set;}
        public int C {get;set;}
        public int D {get;set;}
        public override string ToString()
        {
            return $"{A}:{B}:{C}:{D}";
        }
    }
