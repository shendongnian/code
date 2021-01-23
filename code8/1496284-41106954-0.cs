    public bool isExit;
    public bool deadEnd;
    public bool roomEnd;
    tre.isExit = true;
    dun.deadEnd = true;
    tow.roomEnd = true;
    if (dun.roomEnd == true)
    {
        Console.WriteLine("You've fallen into the Dungeons of the Dead. Try again");
    }
    else if (tow.roomEnd)
    {
        Console.WriteLine("You been caught by the Kings guard and have been placed in the tower for life.Try again");
    }
    else if (tre.isExit)
    {
        Console.WriteLine("You have found the treaure... now run!!");
    }
    else
    {
        Console.WriteLine("Too scared.....");
    }
    return
