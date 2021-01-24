    var collection = new [] { 2, 7, 7, 7, 2, 6, 4 }.ToList();
    for (int i = 0; i < collection.Count - 1; i++)
    {
        if (array[i] == collection[i + 1])
        {
            collection.RemoveAt(i);
            i--;
        }
    }
