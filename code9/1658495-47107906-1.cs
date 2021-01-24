    public static void Main()
    {
        int number;
        do
        {
            Console.WriteLine("Please enter a number");
            number = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.WriteLine("True value. True value is supplied");
                Console.ReadLine();
                number++;
                while (number >= 21 && number < 27) 
                {
                    Console.WriteLine("False value. False value is supplied");
                    Console.ReadLine();
                    number++;
                } 
            } while (number <= 20);
        } while (number > 27);
    }
