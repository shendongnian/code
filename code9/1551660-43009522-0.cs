    [ComVisible(true)]
    [Guid("097B5B52-C73B-4BD0-A540-802D0BC7C49F")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IFooResult
    {
        int Value { get; set; }
    }
    [ComVisible(true)]
    [Guid("76B6BCBD-6F4D-4457-8A85-CDC48F4A7613")]
    [ClassInterface(ClassInterfaceType.None)]
    public class FooResult : IFooResult
    {
        [DispId(1)]
        public byte[] Buffer { get; set; }
    }
