        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello and Welcome to the Programming Lottery!"); //Just greetings and instructions.
                Console.WriteLine("You'll now get to choose ten different numbers to play with. ");
                Console.WriteLine("Go ahead and type them in.");
                int[] lotteri = new int[10]; //Array to catch ten numbers input.
                for (int i = 0; i < lotteri.Length; i++)
                {
                    lotteri[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Very good! Now we'll see if you won anything!");
                Random rnd = new Random();
                int rnumber = rnd.Next(1, 100);
                bool isWin = false;
                isWin = lotteri.Contains(rnumber);
                Console.WriteLine("Lottery number is::" + rnumber);
                if (isWin)
                {
                    Console.WriteLine("Very good! Now we'll see if you won anything!");
                }
                else
                {
                    Console.WriteLine("Sorry...Better luck next time!!!");
                }
                Console.ReadKey();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Only number are allowed.");
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
            Console.ReadKey();
        }
