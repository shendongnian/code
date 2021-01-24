    for (int i = 0; i < 15; ++i)
    {
        int a = 0;
        int b = 1;
        for (int j = 0; j < i; ++j)
        {
            var temp = a;
            a = b;
            b = temp + b;
        }
        Console.WriteLine(a);
    }
