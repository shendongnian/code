    class Program
    {
        static void Main(string[] args)
        {
            UF uf = new UF(5);
            Console.ReadKey(true);
        }
    }
    class UF
    {
        private int n;
        public UF(int N)
        {
            this.n = N;
            Console.WriteLine(this.n);
        }
        public int N
        {
            get => n;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                else
                {
                    n = value;
                }
            }
        }
    }
