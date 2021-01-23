    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SEC3_LEC19
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                int x, y;
                string num1, num2, choice = "yes";
                string op; // changed to string
                bool again = true;
    
                while (again)
                {
    
                    Console.WriteLine("Enter two integers");
    
                    Console.Write("Enter num1: ");
                    num1 = Console.ReadLine();
    
                    Console.Write("Enter num2: ");
                    num2 = Console.ReadLine();
    
                    Console.Write("Enter the operation [+ - * /]: ");
                    op = Console.ReadLine(); // Read line instead of Read char
    
                    if (!int.TryParse(num1, out x))
                        Console.WriteLine(num1 + " is NaN val set to 0");
    
                    if (!int.TryParse(num2, out y))
                        Console.WriteLine(num2 + " is NaN val set to 0");
    
                    switch (op)
                    {
                        // Changed cases
                        case "+": Console.WriteLine( x + " + " + y + " = " + (x + y)); break;
                        case "-": Console.WriteLine( x + " - " + y + " = " + (x - y)); break;
                        case "*": Console.WriteLine( x + " * " + y + " = " + (x * y)); break;
                        case "/":
                            if (y == 0)
                                Console.WriteLine("Division by zero not allowed!");
                            else
                                Console.WriteLine( x + " / " + y + " = " + (x - y));
                            break;
    
                        default:
                            Console.WriteLine("Operator Unrecognized"); break;
                    }
    
                    Console.Write("Go again? [yes/no]: ");
    
                    choice = Console.ReadLine();
    
                    switch (choice.ToLower())
                    {
                        case "yes": again = true; break;
                        case "no": again = false; break;
                        default: Console.WriteLine( "Unrecognized choice!"); break;
                    }
                }
    
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }
    }
