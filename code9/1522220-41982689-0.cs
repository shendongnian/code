    public struct Foo
    {
        public string ReadOnlyString { get; }
        public Foo( string prop )
        {
            ReadOnlyString = prop;
        }
    }
