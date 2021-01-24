    static void DettachFromStdIO()
    {
        Console.In.Close();
        Console.Out.Close();
        Console.Error.Close();
    }
