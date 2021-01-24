     while (true)
            {
                Thread.Sleep(100);
                if (!Console.KeyAvailable)
                {
                    continue;
                }
                var input = Console.ReadKey(true);
                if (input.Modifiers != ConsoleModifiers.Control)
                {
                    continue;
                }
                if (input.Key == ConsoleKey.S)
                {
                    Server?.Dispose();
                }
                
            }
