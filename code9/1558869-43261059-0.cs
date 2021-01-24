            var rnd = new Random(); //defined the random outside the for-loop for reusing
            do //replaced the goto with a do..while
            {
                Console.Clear(); //call clear once before the main loop to reset the input
                for (int i = 0; i < 50; i++)
                {
                    Console.SetCursorPosition(0, 0); //go back to the top instead of clearing
                    for (int y = 0; y < 10; y++)
                    {
                        for (int x = 0; x < 32; x++)
                        {
                            Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 5);
                            Console.Write("\u2588");
                        }
                        Console.WriteLine();
                    }
                }
                Console.ResetColor();
            } while (Console.ReadLine() == "repeat");
