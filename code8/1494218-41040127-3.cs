    int sum = 0;
    int i = 0;
    while (i < arr.GetLength(0))
    {
        int j = 0;
        while (j < arr.GetLength(1))
        {
            sum += arr[i, j];
            j += 1;
        }
        i += 1;
    }
    return sum;
