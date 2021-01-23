    /// <summary>
    /// Removes a collection of the specified index count at the specified index from the referenced array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="size"></param>
    /// <param name="index"></param>
    public static void Remove<T>(ref T[] array, int count, int index)
    {
    	if (index + count >= array.Length || index >= array.Length || count > array.Length) { throw new ArgumentOutOfRangeException(); }
    	for (int i = 0; i < array.Length; i++) { if (i == index) i += count - 1; else if (i - count >= 0) array[i - count] = array[i]; }
    	Array.Resize(ref array, array.Length - count);
    }
