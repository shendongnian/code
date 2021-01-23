    using System;
    
    namespace Calculator
    {
        class Program
        {
            public static void Main(string[] args)
            {
    
            }//<-----------
    
            public int number01;
            public int number02;
            public int Number03
            {
                get
                {
                    return number02 / number01;
                }
            }//<----------
    
            class Program1 : Program
            {
    
                public void DivideFinal()//<---- void not int
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
    }
