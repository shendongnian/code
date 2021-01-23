            Random numbergenerator = new Random();
           
            int score = 0; // THIS IS THE SCORE
         
            while (true)
            {
                int num1 = numbergenerator.Next(1, 11);
                int num2 = numbergenerator.Next(1, 11);
                Console.WriteLine("Whats " + num1 + " times " + num2 + "?");
                var answer = Convert.ToInt32(Console.ReadLine());
                if (answer == num1 * num2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thats the correct answer!");
                    Console.ResetColor();
                    ++score; // Gives score
                    Console.WriteLine("Your score: " + score);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bummer, try again!");
                    Console.ResetColor();
                    Console.WriteLine("Your score: " + score);
                }
            }
