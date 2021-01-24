    public static void randomMovement()
    {
        Random randMove = new Random();
        int x = 1;
        int y = 1;
        Console.CursorLeft = x;
        Console.CursorTop = y;
        while (true)
        {
            int irandom = randMove.Next(4);
            if (irandom == 0 && mazeBluePrint[y, x - 1] == 0)
            {
                x--;
                printMv();
                break;
            }
            else if (irandom == 1 && mazeBluePrint[y, x + 1] == 0)
            {
                x++;
                printMv();
                break;
            }
            else if (irandom == 2 && mazeBluePrint[y - 1, x] == 0)
            {
                y--;
                printMv();
                break;
            }
            else if (mazeBluePrint[y + 1, x] == 0)
            {
                y++;
                printMv();
                break;
            }
        }
    }
