	public ICollection<TKey> Keys
	{
		get { return GetKeys(); }
	}
	private ReadOnlyCollection<TKey> GetKeys()
	{
		int locksAcquired = 0;
		try
		{
			AcquireAllLocks(ref locksAcquired);
			int count = GetCountInternal();
			if (count < 0) throw new OutOfMemoryException();
			List<TKey> keys = new List<TKey>(count);
			for (int i = 0; i < _tables._buckets.Length; i++)
			{
				Node current = _tables._buckets[i];
				while (current != null)
				{
					keys.Add(current._key);
					current = current._next;
				}
			}
			return new ReadOnlyCollection<TKey>(keys);
		}
		finally
		{
			ReleaseLocks(0, locksAcquired);
		}
	}
