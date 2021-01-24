    public struct Foo
    {
        public Int32 A { get; set; }
    }
    public class Service
    {
        public Service(Foo foo)
        {
            this._foo = foo;
        }
        private Foo _foo;
        public void Set(Int32 a)
        {
            this._foo.A = a;
        }
        public void Print()
        {
            Console.WriteLine(this._foo.A);
        }
    }
