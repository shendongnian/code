    for (int j = 0; j < w; j++)
    {
        for (int i = 0; i < h; i++)
        {
            if (j < list[i].Count)
                Console.Write(list[i][j]);
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }
    // Prints:
    // JM
    // oi
    // nk
    //  e
