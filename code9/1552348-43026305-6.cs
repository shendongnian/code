    public class Impl : IInterfaceA<int>, IInterfaceA<string>
    {
        public int TheProperty { get; set; }
        string IInterfaceA<string>.TheProperty { get; set; }
    }
