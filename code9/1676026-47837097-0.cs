    private static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
    {
        if (e.Key == Keys.A)
           OnPressedA();
        else if (e.Key == Keys.B)
           OnPressedB();
    }
    private static void OnPressedA()
    {
        Console.WriteLine("A was pressed.");
    }
    private static void OnPressedB()
    {
        Console.WriteLine("B was pressed.");
    }
