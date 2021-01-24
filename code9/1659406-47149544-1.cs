    public static void Delete(int index)
    {
        if (index >= array.Length)
        {
            return;
        }
        if (index == array.Length - 1)
        {
            array[index] = null;
            return;
        }
        for (int i = index; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = null;
    }
