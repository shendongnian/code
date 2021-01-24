    while (ai < tab.Length)
    {
        bj = 0;
        Console.Write("tab[{0}] = ", ai);
        while (bj < tab[ai].Length)
        {
            tab[ai][bj] = num++;
            Console.Write("{0} ", tab[ai][bj]);
            bj++;
        }
        Console.WriteLine("");
        ai++;
    }
