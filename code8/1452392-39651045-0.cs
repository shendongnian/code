    class A
    {
        public readonly int x = 42;
        public readonly int y;
        public A(int y)
        {
            this.y = y;
        }
        public virtual A copy(int y)
        {
            return new A(y);
        }
    }
    class B : A
    {
        public B(int y) : base(y)
        {
        }
        public override A copy(int y)
        {
            return new B(y);
        }
    }
