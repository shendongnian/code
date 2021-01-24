    using ProtoBuf;
    using System;
    
    [Flags]
    public enum Categories
    {
        Invalid = 0x0,
        A = 0x1,
        B = 0x2,
        C = 0x4,
        D = 0x8,
        Global = A | B | C | D,
    }
    [ProtoContract]
    public class X
    {
        [ProtoMember(1)]
        public Categories Val { get; set; }
        public override string ToString() => Val.ToString();
    }
    static class P
    {
        static void Main()
        {
            var orig = new X { Val = Categories.D | Categories.B };
            var cloneObj = Serializer.DeepClone(orig);
            Console.WriteLine(cloneObj);
    
            var cloneEnum = Serializer.DeepClone(orig.Val);
            Console.WriteLine(cloneEnum);
        }
    }
