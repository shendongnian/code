    public static void randomMovement()
    {
        Random randMove = new Random();
        int x = 1;
        int y = 1;
        int irandom = randMove.Next(4);
        Console.CursorLeft = x;
        Console.CursorTop = y;
        if (irandom == 0 && mazeBluePrint[y, x - 1] == 0)
        {
            x--;
            printMv();
        }
        else if (irandom == 1 && mazeBluePrint[y, x + 1] == 0)
        {
            x++;
            printMv();
        }
        else if (irandom == 2 && mazeBluePrint[y - 1, x] == 0)
        {
            y--;
            printMv();
        }
        else if (mazeBluePrint [y + 1, x] == 0)
        {
            y++;
            printMv();
        }
    }
