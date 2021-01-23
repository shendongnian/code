    static void printRunning(Thread delEmpty)
        {
            Console.CursorVisible = false;
            for (int cnt = 0; delEmpty.IsAlive; cnt++)
            {
                switch (cnt % 3)
                {
                    case 0:
                        Console.Write("Running.");
                        break;
                    case 1:
                        Console.Write("Running..");
                        break;
                    case 2:
                        Console.Write("Running...");
                        break;
                }
                Thread.Sleep(1000);
                Console.SetCursorPosition(0, 0);
                Console.Clear();
            }
            Console.Write("Finished!");
            Console.CursorVisible = true;
        }
    
