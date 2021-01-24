    Point point = new Point(5,5);
    for (int y = 0; y <= point.Y; y++)
    {
        for (int x = 0; x <= point.X; x++)
        {
            if ((x == point.X) && (y == point.Y))
            {
                Console.Write("X");
                Break;
            }
            Console.CursorLeft++;
        }
        Console.CursorTop++;
    }
