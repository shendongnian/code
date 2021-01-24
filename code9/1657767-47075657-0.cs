    class Program
    {
        public static int i = 0;
        static void Main(string[] args)
        {
            i++;
            i.Print();
        }
    }
    static class Extensions
    {
        public static void Print(this int i)
        {
            Console.WriteLine(Program.i);
            Console.WriteLine(i);
        }
    }
