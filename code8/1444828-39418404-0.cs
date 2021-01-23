    [DebuggerTypeProxy(typeof(SomeTypeDebugView))]
    public class SomeType
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
        internal class SomeTypeDebugView
        {
            private SomeType _someType;
            public SomeTypeDebugView(SomeType someType)
            {
                _someType = someType;
            }
            public string Foo { get { return _someType.Foo; } }
        }
    }
    class Program
    {
        static void Main()
        {
            var someType = new SomeType();
            someType.Foo = "foo";
            someType.Bar = "bar";
            Debugger.Break();
        }
    }
