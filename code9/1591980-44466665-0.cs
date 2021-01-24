    public static IEnumerable<T> SplitAndReverse<T>(this IEnumerable<T> sequence, int size)
    {
        // Check if sequence is null
        if (size <= 0)
            throw new ArgumentOutOfRangeException("size can only be a positive number");
        // just return
        return sequence;            
    }
