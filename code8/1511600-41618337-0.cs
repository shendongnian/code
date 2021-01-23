    var c = new List<int>();
    for (int i = 0; i < a.Length - 1;)
    {
        c.Add(i);
        if (i < a.Length - 2 && a[i + 2] < a[i + 1])
            i += 2;
        else
            i += 1;
    }
    c.Add(a[a.Length - 1]);
