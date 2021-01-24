    /// <summary>
    /// Returns the index of an item in inputArray that matches the value of key
    /// </summary>
    /// <typeparam name="T">The type of objects in the array</typeparam>
    /// <param name="inputArray">An array of items to search</param>
    /// <param name="key">A key item value to search for</param>
    /// <returns>The index of an item that matches key, or -1 if no match is found</returns>
    public static int BinarySearchIterative<T>(T[] inputArray, T key) 
        where T : IComparable<T>
    {
        int min = inputArray.GetLowerBound(0);
        int max = inputArray.GetUpperBound(0);
        while (min <= max)
        {
            int mid = (min + max) / 2;
            int comparison = key.CompareTo(inputArray[mid]);
            if (comparison == 0)
            {
                return mid;
            }
            else if (comparison < 0)
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }
        return -1;
    }
