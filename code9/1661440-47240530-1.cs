    private static int[] CreateArrayAndFillWithIndexValue(int size)
    {
        Debug.Assert(size >= 0);
        var array = new int[size];
        for (var i = 0; i < size; i++)
        {
            array[i] = i;
        }
        return array;
    }
