    private static void Sum(long startNumber, long endNumber, out long output)
    {
        long result = 0;
        for (long i = startNumber; i <= endNumber; i++)
        {
            result += i;
        }
        output = result;
    }
