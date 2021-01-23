    public void Add(T item)
    {
        var hash = item.GetHashCode();
        if (hashes.Contains(hash))
            return;
        hashes.Add(hash);
        items.Add(item);
    }
    public bool Remove(T item)
    {
        var hash = item.GetHashCode();
        if (!hashes.Contains(hash))
            return false;
        hashes.Remove(item.GetHashCode());
        return items.Remove(item);
    }
