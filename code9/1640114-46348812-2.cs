    class Program
    {
        static void Assign(ref int x, ref int z)
        {
            x = 3;
            z = 2;
        }
        static void Sum(int x, int z)
        {
            Console.WriteLine(x + z);
        }
        static void Main(string[] args)
        {   
            int x = 0, z = 0;
            Assign(x, z);
            Sum(x, z);
        }
    }
