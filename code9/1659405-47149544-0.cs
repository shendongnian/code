    public static void Delete(int a)
    {
        if (a >= array.Length || a < 0)
        {
            return;
        }
        if (a == array.Length - 1)
        {
            array[a] = null;
        }
        for (int i = a; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = null;
    }
