    int[,] array = new int[4, 3] { 
          { 1, 2, 3 },
          { 4, 5, 6 },
          { 7, 8, 9 },
          { 10, 11, 12 }
       };
    
    for(int i = 0; i <= array.GetUpperBound(1); i++)
        Console.WriteLine(array[0,i]); // getting all items from first dimension
