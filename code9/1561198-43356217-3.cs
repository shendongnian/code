    var set = new HashSet<GameBoard>();
    set.Add(new GameBoard(new int[,]
    {
        {1, 2, 3},
        {8, 0, 4},
        {7, 6, 5},
    }));
    bool contains = set.Contains(new GameBoard(new int[,]
    {
        {1, 2, 3},
        {8, 0, 4},
        {7, 6, 5},
    })); // false
