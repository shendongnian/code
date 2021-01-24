    int[] Arr1 = { 0, 1, 2, 5, 0, 7, 6, 8 };
    int[] Arr2 = { 0, 0, 3, 0, 9, 2, 0, 1 };
    int[] Arr3 = { 0, 2, 1, 0, 1, 0, 0, 0 };
    
    int[][] arrays = { Arr1, Arr2, Arr3 };
    
    int[] result = arrays.Aggregate((a, b) => a.Zip(b, (i, j) => j == 0 ? i : j).ToArray());
