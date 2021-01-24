            startPoint:
            int output = 0;
            Console.Write("Input : ");
            string input = Console.ReadLine();
            string[] inputArray = input.Split(' ');
            foreach (string eachInputValue in inputArray)
            {
                try
                {
                    output += Convert.ToInt32(eachInputValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nPlease input numeric type\n");
                    goto startPoint;
                }
            }
            Console.Write("Output : " + output);
            Console.ReadKey();
        }
