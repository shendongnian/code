    for (int i = 0; i < 5; i++)
    {
        // Declared *inside* the loop, so each iteration will have a separate variable
        int copy = i;
        q.Enqueue(() => Console.WriteLine(copy));
    }
