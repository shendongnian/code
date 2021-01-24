    for (int i = 0; i < columnsAndTheirNames.GetLength(0); ++i) {
        for (int j = 0; j < columnsAndTheirNames.GetLength(1); ++j) {
            Console.Write(columnsAndTheirNames[i, j] + "\t");
        }
        Console.WriteLine();
    }
