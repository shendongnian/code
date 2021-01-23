    public T this[int index]
    {
        get { return items[index]; }
        set { Insert(index, value); }
    }
   
    public int Count => items.Count;
    public bool Contains(T item) => hashes.Contains(item.GetHashCode());
    public IEnumerator<T> GetEnumerator() => items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
