    int[,] test = new int[4, 3]
    {
        {45, 23, 9},
        {3, -4, -134},
        {67, 53, 32},
        {0, 1, 0}
    };
    // test.GetLength(n) will give the length at nth dimension.
    // test.Length will give total length. (4*3)
    var colLength = test.GetLength(1);
    for (int i = 0; i < test.Length - 1; i++)
    {
        for (int j = i + 1; j < test.Length; j++)
        {
            int row1, col1; // for first item
            int row2, col2; // next item
            Get2DIndex(i, colLength, out row1, out col1); // calculate indexes for first item
            Get2DIndex(j, colLength, out row2, out col2); // calculate indexes for next item
            if (test[col2, row2] < test[col1, row1]) // simple swap
            {
                var temp = test[col2, row2];
                test[col2, row2] = test[col1, row1];
                test[col1, row1] = temp;
            }
        }
    }
