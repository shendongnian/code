    private SortedSet<Item> _itemsHashSet = new SortedSet<Item>(new AddedAtComparer());
	public IEnumerable<Item> GetOldestItems(int count)
	{
		return _itemsHashSet.Take(count);
	}
