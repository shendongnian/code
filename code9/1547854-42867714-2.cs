    for (int i = 0; i < 1000; i++)
    {
        container.Add(new Chest(i, $"{i}"));
        var value = container.Get(i);
    }
