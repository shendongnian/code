    var spiral = Spiral(14, 24);
    for(int i = 0; i < spiral.GetLength(0); i++)
    {
        for(int j = 0; j < spiral.GetLength(1); j++)
        {
            Console.Write(spiral[i, j]?.ToString() ?? new string(' ', (j + 1).ToString().Length));
            Console.Write(" ");
        }
        Console.WriteLine();
    }
