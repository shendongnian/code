            Random numbers = new Random();
            Random1 = numbers.Next(0, 11);
            Count = Count + 1;
            Random numbers2 = new Random();
            Random2 = numbers.Next(0, 11);
            Console.WriteLine(Random1 + "x" + Random2 + "=");
            //Modified
            int input = 0;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Invalid Input. Please enter a valid integer.");
                }
                else
                {
                    if (input >= 1 && input <= 100)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Input. Please enter a integer between 1-100.");
                }
            }
            //Modified
