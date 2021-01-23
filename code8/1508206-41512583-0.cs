    public static void Foo(bool execute, int x)
    {
        if (execute)
        {
            int localx = x;
            Task.Run(() => Console.WriteLine(localx));
        }
    }
