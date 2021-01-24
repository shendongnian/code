    int[,] array = new int[3, 3] { { 1, 2, 3 }, 
                                   { 4, 5, 6 }, 
                                   { 7, 8, 9 } };  
    int[] result = Enumerable.Range(0, array.GetUpperBound(1)+1)
                             .Select(y => Enumerable.Range(0, array.GetUpperBound(0)+1)
                             .Select(x => array[y,x]).Sum()).ToArray(); //[6,15,24]
