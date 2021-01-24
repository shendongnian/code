    public static int FindLast<T>(T[] array, T value)
        where T : IEquatable<T>
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i].Equals(value))
            {
                return i;
            }
        }
        return -1;
    }
