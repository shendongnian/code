    Func<TempoMarking, IComparable> selectorGetter = null;
    // Setting the selectorGetter here
    for (int i = 0; i < Collection.Count; i++)
    {
        for (int j = 0; j < Collection.Count - 1; j++)
        {
            YourType currentItem = Collection[j];
            if (selectorGetter(currentItem).CompareTo(selectorGetter(Collection[j + 1])) == 1)
            {
                Collection.Remove(currentItem);
                Collection.Insert(j + 1, currentItem);
            }
        }
    }
