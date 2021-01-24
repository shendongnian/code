    Console.WriteLine("Enter your guess");
                if (!ulong.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please enter numerical value");
                    Environment.Exit(-1);
                }
