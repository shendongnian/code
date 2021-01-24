            try
            {
                Console.WriteLine("Type 1st number: ");
                num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("type 2nd number: ");
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("type operation( x , / , +, -, Fs) ");
                operation = Console.ReadLine();
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Sorry moron you can't divide by zero");
            }
