    class Program
    {
        public static int i = 0;
        public static void Main()
        {
            (i++).Print();//  increment after print
            (++i).Print();// print after increment
        }
    }
    static class Extensions
    {
        public static void Print(this int i)
        {
            Console.WriteLine(i);
        }
    }
