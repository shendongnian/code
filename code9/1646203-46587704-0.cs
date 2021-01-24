        static void Main(string[] args)
        {
            dynamic foo = new Foo();
            // conditional breakpoint 'foo.Nodes == null' here
        }
        internal class Foo
        {
            public IEnumerable<Foo> Nodes = null;
        }
