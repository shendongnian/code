    class A { }
    class B : A { }
    class C : A { }
    interface IContainer
    {
        IEnumerable<A> value { get; }
    }
    class BContainer : IContainer
    {
        public B[] value { get; set; }
        IEnumerable<A> IContainer.value => this.value;
    }
    class CContainer : IContainer
    {
        public C[] value { get; set; }
        IEnumerable<A> IContainer.value => this.value;
    }
