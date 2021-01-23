    int[,] board = new int[,] {
      { 0, 1, 1, 0, 0, 0, 0 },
      { 0, 1, 1, 0, 1, 1, 1 },
      { 0, 1, 1, 0, 1, 1, 1 },
      { 0, 1, 1, 0, 1, 1, 1 },
      { 0, 1, 1, 0, 1, 1, 1 },
    };
    // room for 3-letter words
    Console.Write(String.Join(Environment.NewLine, ScanBoard(board, 0, 3)));
