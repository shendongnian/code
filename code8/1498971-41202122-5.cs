    bool isOnEmptyColumn = (x == EmptyX);
    bool isOnEmptyRow = (y == EmptyY);
    bool isOnEmptyCell = isOnEmptyColumn && isOnEmptyRow;
    if (isOnEmptyCell)
    {
        Console.Write("0");
    }
    else
    {
        Console.Write("1");
    }
