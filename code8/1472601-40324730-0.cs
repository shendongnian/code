     Random r = new Random();
    
                int secretNumber = r.Next(1, 11);
                int i = 0;
                int chance = 5;
    
                Console.WriteLine("Game: guess number");
    
                while (i < chance)
                {
                    Console.WriteLine("Your turn");
    
                    if (secretNumber == int.Parse(Console.ReadLine()))
                    {
                        Console.WriteLine("You won!");
                        break;
                    }
    
                    i++;
                }
    
                if (i == chance)
                {
                    Console.WriteLine("You lost!");
                    Console.WriteLine("The secret number is " + secretNumber);
                }
