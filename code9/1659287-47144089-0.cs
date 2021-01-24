    public static void PaddedResize<T>(
        List<T> list,
        int size,
        T padding = default(T)
    ) {
        // Compute difference between actual size and desired size
		var deltaSize = list.Count - size;
		if (deltaSize < 0) {
            // If the list is smaller than target size, fill with `padding`
			list.AddRange(Enumerable.Repeat(padding, -deltaSize));
		} else {
            // If the list is larger than target size, remove end of list
			list.RemoveRange(size, deltaSize);
		}
	}
