    int arrLength = 5;
    float grandTotal = 100; 
    float[] arr = new float[arrLength];
    int arrLengthInc = arrLength + 1;
    int sum = (arrLengthInc * arrLengthInc / 2) + (arrLengthInc / 2) - 1;
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = (i + 2) * grandTotal / sum;
    }
    // output: // [10, 15, 20, 25, 30]
    Console.WriteLine("[{0}]", string.Join(", ", arr)); 
