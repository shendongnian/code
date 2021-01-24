    for (int i = 0; i < 20; i++)
    {
        var rand = random.Next(0,80);
        if (test[rand] == 1)
        {
            i--;
            continue;
        }
        test[rand] = 1;
    }
    for (int i = 0; i < test.Length; i++)
    {
        if (test[i] != 1)
            test[i] = 0;
    }
