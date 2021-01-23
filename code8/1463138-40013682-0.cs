    using System.IO;
    using System;
    
    class Program
    {
        static void Main()
        {
            int x;
            int y;
            
            
            Console.WriteLine("Welcome to my calculator program!");
            Console.WriteLine("This calculator for now can only do + and -");
            
            // Reads x and y from console.
            Console.WriteLine("Enter x :");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter y :");
            y = Convert.ToInt32(Console.ReadLine());
    
            Console.WriteLine("Enter operator for corresponding operation on x and y.\nSupported operations x - y and x + y");
            string inputOpr = Console.ReadLine(); // Stores operation to perform
            
            // Compares input operator to perform operation.
            if (inputOpr == "-"){
                Console.WriteLine("you chose to use minus");
                int result = x - y;
                Console.WriteLine("Result: {0}", result);
                Console.WriteLine("Press a key to exit");
                Console.ReadLine();
            }
            
            else if (inputOpr == "+"){
                Console.WriteLine("you chose to use plus");
                int result = x + y;
                Console.WriteLine("Result: {0}", result);
                Console.WriteLine("Press a key to exit");
                Console.ReadLine();
            }
            else{
                Console.WriteLine("Invalid Input");
            }
         }
    }
