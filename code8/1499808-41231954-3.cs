    class MyList<T> : List<T>
    {
        public new void Add(T item)
        {
            if (!this.Contains(item)) base.Add(item);
        }
    }
