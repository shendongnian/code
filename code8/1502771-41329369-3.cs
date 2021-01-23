    for (int j = w - 1; j >= 0; j--)
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
    //  e
    // nk
    // oi
    // JM
