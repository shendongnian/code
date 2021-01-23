    class Program
    {
        public int[] Concat(int[] x, int[] y)
        {
            int[] z = x.Concat(y).ToArray();
            return z;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            int[] x = new int[] { 1, 2, 3 };
            int[] y = new int[] { 4, 5, 6 };
            int[] z = program.Concat(x, y);
            Console.ReadLine();
        }
    }
