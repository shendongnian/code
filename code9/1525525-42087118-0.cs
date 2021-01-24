    class cell
    {
        public cell()
        {
            T = -1;
            M = -1;
            S = false;
        }
        public cell(int t, int m)
        {
            T = t;
            M = m;
            S = false;
        }
        public int T { get; }
        public int M { get; }
        public bool S { get; }
    }
