    int[,] array = new int[3, 3] { { 1, 2, 3 }, 
                                   { 1, 2, 3 }, 
                                   { 1, 2, 3 } };  
    int[] result = Enumerable.Range(0, array.GetUpperBound(1) + 1)
                             .Select(y => Enumerable.Range(0, array.GetUpperBound(0) + 1)
                             .Select(x => array[x, y]).Sum()).ToArray(); // [3,6,9]
