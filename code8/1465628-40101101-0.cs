    DateTime now = DateTime.Now; // When you start.
    for (int i = 0; i < 40; i++)
    {
        // Your logic for adding the tab here...
        AddTab();
    }
    TimeSpan elapsed = DateTime.Now - now; //When you're done.
    Console.WriteLine(elapsed.TotalMilliseconds);
