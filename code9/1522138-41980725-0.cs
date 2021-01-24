    class Foo : IDisposable
    {
        public Foo()
        {
        }
        public void Dispose()
        {
            Resource.Release = true;
        }
        public Resource Resource { get; set; }
    }
