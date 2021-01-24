    public static T[][] SplitArray<T>(T[] array, int size) {
        // calculate how long the resulting array should be.
        var finalArraySize = array.Length / size + 
            (array.Length % size == 0 ? 0 : 1);
        var finalArray = new T[finalArraySize][];
        for (int i = 0 ; i < finalArraySize ; i++) {
            // Skip the elements we already took and take new elements
            var subArray = array.Skip(i * size).Take(size).ToArray(); // Take actually will return the rest of the array instead of throwing an exception when we try to take more than the array's elements
            finalArray[i] = subArray;
        }
        return finalArray;
    }
