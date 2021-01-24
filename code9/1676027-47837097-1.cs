    private static void Main()
    {
        HotKeyManager.RegisterHotKey(key: Keys.G, modifiers: HotKeyEventArgs.KeyModifiers.Alt);
        HotKeyManager.RegisterHotKey(key: Keys.P, modifiers: HotKeyEventArgs.KeyModifiers.Alt);
        HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(HotKeyManager_HotKeyPressed);
        Console.ReadLine();
    }
    private static void HotKeyManager_HotKeyPressed(object sender, HotKeyEventArgs e)
    {
        if (e.Key == Keys.G && e.Modifiers == HotKeyEventArgs.KeyModifiers.Alt)
           OnPressedAltG();
        else if (e.Key == Keys.P && e.Modifiers == HotKeyEventArgs.KeyModifiers.Alt)
           OnPressedAltP();
    }
    private static void OnPressedAltG()
    {
        Console.WriteLine("Alt+G was pressed.");
    }
    private static void OnPressedAltP()
    {
        Console.WriteLine("Alt+P was pressed.");
    }
