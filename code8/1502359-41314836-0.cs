     {
                Random rnd = new Random();
                int rndNumber1 = rnd.Next(1, 100);
                int rndNumber2 = rnd.Next(1, 100);
        
                while (true)
                {
                    try
                    {
                        Console.Write("What equals " + rndNumber1 + " + " + rndNumber2 + ": ");
                        string input = Console.ReadLine();
                        int answer = int.Parse(input);
        
                        if (answer == rndNumber1 + rndNumber2)
                        {
                            Console.WriteLine("Your answer is correct.");
                            break;
                        }else{
         Console.WriteLine("Your answer is incorrect. Try again.");
        }
                    }
                    catch
                    {
                        
                    }
                }
            }
