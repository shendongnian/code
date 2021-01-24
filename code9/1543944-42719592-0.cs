    class Foo : IDisposeable
    {
        public void Close() { doBar(); }
        public void Dispose() { doBaz(); }
    }
