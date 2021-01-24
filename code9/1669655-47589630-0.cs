    int[] oldItems = new int[] { 1, 2, 3 };
    int[] newItems = new int[oldItems.Length * 2];
    for (int i = 0; i < oldItems.Length; i++)
    {
        newItems[i] = oldItems[i];
    }
    newItems[oldItems.Length + 1] = 4;
