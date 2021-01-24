            else if (operation == "/")
            {
                try
                {
                    result = num1 / num2;
                    Console.WriteLine("{0} / {1} = {2}", num1, num2, result);
                    Console.ReadLine();
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Sorry moron you can't divide by zero");
                }
            }
