    /// <summary>
    /// Generates a non-negative random integer.
    /// </summary>
    /// <returns>A non-negative random integer.</returns>
    internal int Next()
    {
        int result;
        // The CLR implementation just fudges
        // Int32.MaxValue down to (Int32.MaxValue - 1). This implementation
        // errs on the side of correctness.
        do
        {
            result = InternalSample();
        }
        while (result == Int32.MaxValue);
        if (result < 0)
        {
            result += Int32.MaxValue;
        }
        return result;
    }
