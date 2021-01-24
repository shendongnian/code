    public static int TestMethod(int[][] matrix)
    {
        int sum = 0;
        for (int column = 0; column < 4; column++)
            for (int row = 0; row < 3; row++)
                if (row == 0 || matrix[row - 1][column] != 0 )
                    sum += matrix[row][column];
        return sum;			
    }
