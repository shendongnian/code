        class Foo
        {
            public Foo Create(string bar)
            {
                return bar == null ? new Foo() : new Foo(bar);
            }
            public Foo() : this("foobar")
            {
            }
            public Foo(string bar)
            {
                Bar = bar;
            }
            public string Bar { get; }
        }
