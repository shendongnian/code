    int length = 20;
    int i = 0;
    while (i < length)
    {
        Print(i); // This is just an example.
        if (i == 5 && !condition(x))
        {
            x++; // Do something with x.  Again, an example.
            continue;
        }
        i++;
    }
