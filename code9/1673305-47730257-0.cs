    internal class Program
    {
        private static void Main(string[] args)
        {
            int x = 10;
            int y = 20;
            ref var rez = ref TryClass.Multiply(x, y);
            rez++;
            Console.WriteLine(rez);
            TryClass.DoAfter();
            Console.ReadLine();
        }
    }
