      ...
      // Initialization is quite a complex, but it's the only such a fragment  
      List<List<int>> matrix = Enumerable
        .Range(1, r)              // r columns
        .Select(i => Enumerable   // i - row index which we ignore
          .Range(1, c)            // c columns 
          .Select(index => 0)     // assign each item to 0 
          .ToList())              // inner list
        .ToList();                // outer list
    
      for (int row = 0; row < r; row++)
      {
         for (int col = 0; col < c; col++)
         {
            Console.Write("Enter value for matrix[{0},{1}] = ", row, col);
            // please, notice [row][col] instead of [row, col]
            matrix[row][col] = (int)Convert.ToInt32(Console.ReadLine());
         }
      }
