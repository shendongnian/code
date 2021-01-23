    //...
         int[,] matrix = new int[r, c + 1];
         /*Insert Values into Main Matrix
         --------------------------------------------------------------------------------*/
        //Fill the first column manually
        for(int row = 0; row < r; row++) matrix[row, 0] = 0; 
        for (int row = 0; row < r; row++)
        {
            //This loop then starts from the second column, and loops until
            //col <= c instead of just col < c
            for (int col = 1; col <= c; col++)
            {
                Console.Write("Enter value for matrix[{0},{1}] = ", row, col);
                matrix[row, col] = (int)Convert.ToInt32(Console.ReadLine());
            }
        }
    //...
