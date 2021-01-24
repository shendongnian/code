    class Program
        {
            static void Main(string[] args)
            {
                double v1 = 100.5;
                double v2 = 100.56;
                double v3 = 100.49;
                Console.WriteLine(Math.Round(v1, 0,MidpointRounding.AwayFromZero));
                Console.WriteLine(Math.Round(v2, 0, MidpointRounding.AwayFromZero));
                Console.WriteLine(Math.Round(v3, 0, MidpointRounding.AwayFromZero));
    
            }
        }
