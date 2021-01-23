     private static void SumNumbers()
            {
                int numOfInput = 3;
                int index;
                int num = 0;
                for (index = 1; index <= numOfInput; index++)
                {
                    Console.WriteLine("Please give the value of no " + index);
                    num += int.Parse(Console.ReadLine()); 
                    
                }
                Console.WriteLine("The sum is:" + num.ToString());
                Console.ReadLine(); // to keep console alive 
            }
