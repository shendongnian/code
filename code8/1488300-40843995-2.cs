        for (int row = 0; row < r; row++)
        {
          for (int col = 0; col < c - 1; col++) // reduce column loop by one
          {
            if (col == 0)
            {
              matrix[row, col] = 0;
            }
            else
            {
              Console.Write("Enter value for matrix[{0},{1}] = ", row, col - 1);
              matrix[row, col] = (int)Convert.ToInt32(Console.ReadLine());
            }
         }
       }
