    public class Test
    {
        private int Method(int x = 0) => x;
        public int Method(int x = 1, int y = 2) => x + y;
        public int Foo => Method(0);
    }
