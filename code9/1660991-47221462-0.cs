     Console.WriteLine("Press Space to start the game!");
                    Console.WriteLine("Press Esc to quit the game!");
                    
     bool isGameClose = false;
            while (!isGameClose)
            {
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
    
                if(pressedKey == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("Game is On");
                }
                else if(pressedKey == ConsoleKey.Escape)
                {
                    isGameClose = true;
                }
            }
            Console.WriteLine("Game Exited!");
