    class B
    {
        public IEnumerable<int> Foo => yield return 1;
    }
    class A : B
    {
        private B b;
        public IEnumerable<int> Foo => b.Foo.Where(x => true);
        public A(B b)
        {
            this.b = b;
        }
    }
