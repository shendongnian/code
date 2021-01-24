    for (int y = -4; y < 5; y++)
    {
        for (int x = -4; x < 5; x++)
        {
            var dst = CalculateDistance(new Vector2(x, y), new Vector2());
            Console.Write($"{((int)dst):D1} ");
        }
        Console.WriteLine();
    }
