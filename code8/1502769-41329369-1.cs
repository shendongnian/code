    for (int i = 0; i < h; i++)
    {
        for (int j = 0; j < w; j++)
        {
            if (j < list[i].Count)
                Console.Write(list[i][j]);
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }
    // Prints:
    // Jon
    // Mike
