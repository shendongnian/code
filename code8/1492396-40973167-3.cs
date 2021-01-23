    namespace Calculator
    {
        class Calculator
        {
            public int number01;
            public int number02;
            public int Number03
            {
                get
                {
                    return number02 / number01;
                }
            }
    
            public void DivideFinal()
            {
                Console.Write("Enter a number to be divided: ");
                Console.ReadKey();
                number01 = Convert.ToInt32(Console.ReadKey());
                Console.WriteLine("Enter another number to be divided");
                number02 = Convert.ToInt32(Console.ReadKey());
                Console.WriteLine("The result is: " + Number03);
                Console.ReadKey();
            }
        }
    }
