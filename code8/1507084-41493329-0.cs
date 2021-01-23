            string answer;
            while (true)
            {
                Console.WriteLine("Enter your favorite animal:");
                answer = Console.ReadLine();
                if (new Regex("^[A-Z][a-z]*$").IsMatch(answer))
                {
                    Console.WriteLine("You like {0}s. Cool!", answer);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("'{0}' is not a valid answer.", answer);
                    Console.WriteLine();
                    Console.WriteLine("Make sure:");
                    Console.WriteLine("You are entering a one word answer.");
                    Console.WriteLine("You are only using letters.");
                    Console.WriteLine("You are capitalizing the first letter of the word.");
                    Console.WriteLine();
                    Console.WriteLine("Try again:");
                }
            }
