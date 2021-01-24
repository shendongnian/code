    public static void PaddedResize<T>(
        List<T> list,
        int size,
        Func<T> paddingFactory // Changed parameter to a factory function
    ) {
        // Compute difference between actual size and desired size
		var deltaSize = list.Count - size;
		if (deltaSize < 0) {
            // If the list is smaller than target size, fill with the result of calling `paddingFactory` for each new item
			list.AddRange(Enumerable.Repeat(0, -deltaSize).Select(_ => paddingFactory()));
		} else {
            // If the list is larger than target size, remove end of list
			list.RemoveRange(size, deltaSize);
		}
	}
