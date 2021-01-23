        public class Foo
        {
            private readonly object _bar;
            public Foo(Bar bar)
            {
                _bar = Activator.CreateInstance(bar.GetType());
            }
            protected Foo(Type bar)
            {
                _bar = Activator.CreateInstance(bar);
            }
            public void Write()
            {
                Console.WriteLine(_bar);
            }
        }
        public class Foo<T> : Foo
        {
            public Foo() : base(typeof(T))
            {
            }
        }
