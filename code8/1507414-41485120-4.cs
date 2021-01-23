    public int IndexOf(T item)
    {
        var hash = item.GetHashCode();
        if (!hashes.Contains(hash))
            return -1;
        return items.IndexOf(item);
    }
    public void Insert(int index, T item)
    {
        var itemAtIndex = items[index];
        if (comparer.Compare(item, itemAtIndex) == 0)
            return;
        var hash = item.GetHashCode();
        if (!hashes.Contains(hash))
        {
            hashes.Remove(itemAtIndex.GetHashCode());
            items[index] = item;
            hashes.Add(hash);
            return;
        }
        throw new ArgumentException("Cannot add duplicate item");
    }
    public void RemoveAt(int index)
    {
        var item = items[index];
        hashes.Remove(item.GetHashCode());
        items.RemoveAt(index);
    }
