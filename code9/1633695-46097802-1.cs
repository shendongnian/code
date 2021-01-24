    var spiral = MakeSpiral(9, 6);
    for(int i = 0; i < spiral.GetLength(0); i++)
    {
        for(int j = 0; j < spiral.GetLength(1); j++)
        {
            Console.Write(spiral[i, j]?.ToString() ?? " ");
            Console.Write(" ");
        }
        Console.WriteLine();
    }
