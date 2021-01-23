    private bool IsOnEmptyCell(int x, int y)
    {
        if (x != EmptyX) return false;
        if (y != EmptyY) return false;
        return true;
    }
    //Main program
    if (IsOnEmptyCell(x,y))
    {
        Console.Write("0");
    }
    else
    {
        Console.Write("1");
    }
