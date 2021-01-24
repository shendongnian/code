      static void Main()
        {
            int number = 10;
            number = MultiplyByTen(number);
            Console.WriteLine(number);
            Console.ReadKey(true);
        }
        static public int MultiplyByTen(int num)
        {
            return num *= 10;
        }
