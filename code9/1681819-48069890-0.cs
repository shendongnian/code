    void M1()
    {
        int[] a = { 1, 2, 3 };
        M2(ref a[1]);
        Console.WriteLine(string.Join(", ", a);
    }
    void M2(ref int i)
    {
        i = 17;
    }
