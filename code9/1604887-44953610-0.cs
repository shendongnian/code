    class A
    {
        public int a;
        public int b;
        public A(int x, int y)
        {
            a = x;
            b = y;
        }
    }
    class B:A
    {
        public int d;
        public int e;
        public B(int x, int y): base (x, y)
        {
            d = x;
            e = y;
        }
    }
    class C:B
    {
        public C(int m, int n) : base(m, n)
    }
