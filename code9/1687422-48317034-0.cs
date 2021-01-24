    class Program
    {
        static void Main(string[] args)
        {
            int const1 = 1;
            int const2 = 2;
            Random rng = new Random();
            string id = $"{const1}{const2}";
            for(int i = 0; i <= 4; i++)
            {
                id += $"{rng.Next(0, 10)}";
            }
            Console.WriteLine(id);
            Console.ReadKey(true);
        }
    }
