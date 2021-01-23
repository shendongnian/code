    public struct InnerStruct
    {
        public bool A;
        public int  B;
    }
    OuterStruct a = new OuterStruct(new InnerStruct { A = true });
    OuterStruct b = new OuterStruct(new InnerStruct { A = false });
    OuterStruct c = new OuterStruct(new InnerStruct { B = 3 });
    OuterStruct d = new OuterStruct(new InnerStruct { B = 4 });
    Console.WriteLine(b.GetHashCode());
    Console.WriteLine(c.GetHashCode());
    Console.WriteLine(d.GetHashCode());
