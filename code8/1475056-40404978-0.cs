    static class x
    {
        static public int y()
        {
            Console.WriteLine("y");
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.Func<int> z = x.y;
            Console.WriteLine(z());
            Console.Read();
        }
    }
