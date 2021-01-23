    public ObservableStack(IEnumerable<T> items)
       : this() // instead of base()
    {
        foreach (var item in items)
        {
            Push(item);
        }
    }
