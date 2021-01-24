    // null means anything is ok, X is 0, Y is 1, Z is 2...
    int?[,] temp = new int?[,]
    {
        {0, 0, null},
        {null, 0, 0}
    };
    int[,] a = new int[,]
    {
        { 0, 1, 1, 2, 4, 4, 1 },
        { 0, 1, 4, 4, 3, 3, 3 },
        { 0, 2, 3, 4, 4, 5, 5 }
    };
    int row, col;
    bool success = CheckPattern(temp, a, out row, out col);
    Console.WriteLine("Success: {0}, row: {1}, col: {2}", success, row, col);
