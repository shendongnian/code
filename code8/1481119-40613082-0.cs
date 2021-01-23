            Console.WriteLine("     Even Table \n");
            int MaxNumber = 100;
            int EvenNumbers = 0;
            int i;
            for (i = 0; i <= MaxNumber; i += 2)
            {
                if (i % 2 == 0)
                {
                    EvenNumbers = i;
                }
                Console.Write(" ");
                Console.Write(EvenNumbers);
                if (i % 20 == 0 && i>0)
                {
                    Console.WriteLine();
                }
            }
