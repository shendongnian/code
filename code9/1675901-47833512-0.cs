    public static T[,] Copy<T>(T[,] a)
        where T : new()
    {
        long n1 = a.GetLongLength(0);
        long n2 = a.GetLongLength(1);
        long offset = 0;
        long length = n1 * n2;
        long maxlength = Int32.MaxValue;
        T[,] b = new T[n1, n2];
        while (length > maxlength)
        {
            System.Array.Copy(a, offset, b, offset, maxlength);
            offset += maxlength;
            length -= maxlength;
        }
        System.Array.Copy(a, offset, b, offset, length);
        return b;
    }
