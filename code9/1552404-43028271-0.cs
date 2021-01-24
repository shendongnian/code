    class Program
    {
        static void Main()
        {
            TailCall(0);
        }
        private static void TailCall(int i)
        {
            Console.WriteLine(i);
            TailCall(++i);
        }
    }
