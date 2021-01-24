    class BContainer : IContainer
    {
        public B[] value { get; set; }
        IEnumerable<A> IContainer.Value => value;
    }
    class CContainer : IContainer
    {
        public C[] value { get; set; }
        IEnumerable<A> IContainer.Value => value;
    }
    
    interface IContainer
    {
        IEnumerable<A> Value { get; }
    }
