    string[] thisCanVaryInLength = new string[3] { "col1,nam1", "col2,nam2", "col3,nam3" };
    string[,] columnsAndTheirNames = new string[2, thisCanVaryInLength.Length];
    for (int i = 0; i < thisCanVaryInLength.Length; i++) {
        var items = thisCanVaryInLength[i].Split(',');
        columnsAndTheirNames[0, i] = items[0];
        columnsAndTheirNames[1, i] = items[1];
    }
    for (int i = 0; i < columnsAndTheirNames.GetLength(0); ++i) {
        for (int j = 0; j < columnsAndTheirNames.GetLength(1); ++j) {
            Console.Write(columnsAndTheirNames[i, j] + "\t");
        }
        Console.WriteLine();
    }
