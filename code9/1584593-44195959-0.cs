    public static void Main()
    {
        // the actual object we care about
        object obj = new Foo { X = 1 };
        // serialize and deserialize via stub
        var stub = new Stub { Data = obj };
        var clone = Serializer.DeepClone(stub);
        // prove it worked
        Console.WriteLine(clone.Data);
        // prove it is a different instance
        Console.WriteLine(ReferenceEquals(obj, clone.Data));
    }
    [ProtoContract]
    public class Foo
    {
        [ProtoMember(1)]
        public int X { get; set; }
        public override string ToString() => $"X={X}";
    }
    [ProtoContract]
    public sealed class Stub
    {
        [ProtoMember(1, DynamicType = true)]
        public object Data { get; set; }
    }
