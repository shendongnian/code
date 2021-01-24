    for (int i = toys.Length - 1; i >= 0; i--)
    {
        if (toys[i] is Ball)
        {
            toys.RemoveAt(i);
        }
    }
