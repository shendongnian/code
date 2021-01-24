    // Client
    using (var itemEnumerator = source.GetItemEnumerator())
    {
        while (itemEnumerator.MoveNext())
            var current = itemEnumerator.Current;
    }
    // Source
    IEnumerator<Disposable> GetItemEnumerator() => this.StreamItems().GetEnumerator();
    private IEnumerable<Disposable> StreamItems()
    {
        while (this.ShouldCreateItem())
        {
            using (var item = this.CreateItem())
            {
                yield return item;
            }
        }
    }
