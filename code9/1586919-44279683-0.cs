    public static void ConsoleWrite(Parent pitem)
    {
        if(pitem?.GetType().IsSubclassOf(typeof(Parent)) == true)
        {
            throw new ArgumentException("Only parent type is allowed", nameof(pitem));
        }
        Console.Write(pitem?.item);
    }
