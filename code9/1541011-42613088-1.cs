    private void Advancedmodewindow_click(object sender, EventArgs e)
    {
        classx.AllocConsole();
        TextWriter writer = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
        Console.SetOut(writer);
        Console.WriteLine("X");
        Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        string line = Console.ReadLine();
        classx.FreeConsole();
    }
