      ...
      // Initialization is quite a complex, but it's the only such a fragment  
      List<List<int>> matrix = Enumerable
        .Range(1, r)
        .Select(i => Enumerable
          .Range(1, c)
          .ToList())
        .ToList();
    
      for (int row = 0; row < r; row++)
      {
         for (int col = 0; col < c; col++)
         {
            Console.Write("Enter value for matrix[{0},{1}] = ", row, col);
            // please, notice [row][col] instead of [row, col]
            matrix[row][col] = (int)Convert.ToInt32(Console.ReadLine());
         }
      }
