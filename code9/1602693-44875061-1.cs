    static void Main(string[] args)
            {
                Cat.NumberOfLegs = 4;
                Snake.NumberOfLegs = 0;
                Human.NumberOfLegs = 2;
    
                Console.WriteLine(Cat.NumberOfLegs);
                Console.WriteLine(Snake.NumberOfLegs);
                Console.WriteLine(Human.NumberOfLegs);
                Console.ReadLine();
            }
