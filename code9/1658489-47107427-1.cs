            Console.WriteLine("Please enter a number");
            int numnber = Convert.ToInt32(Console.ReadLine());
            while (numnber <= 20)
            {
                Console.WriteLine("True");
                Console.ReadLine();
                int number1 = numnber++;
                
                while (numnber > 20)
                {
                    Console.WriteLine("False");
                    Console.ReadLine();
                }
                break;
            }
