    Process[] localByName = Process.GetProcessesByName("notepad");
    int i = localByName.Length;
    while (i > 0)
    {
        // You can use the process Id to pass to other applications or to
        // reference that particular instance of the application.
        Console.WriteLine(localByName[i - 1].Id.ToString());
        i -= 1;
    }
