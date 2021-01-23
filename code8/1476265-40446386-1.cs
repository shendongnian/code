    Console.WriteLine("Ctrl+c to end input");
    StringBuilder s = new StringBuilder();
    Console.CancelKeyPress += delegate
    {
        // Eat this event so the program doesn't end
    };
    
    int c = Console.Read();
    while (c != -1)
    {
        s.Append((char)c);
        c = Console.Read();
    }
    
    string[] results = s.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
