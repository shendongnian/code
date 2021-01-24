    public static int[] sumcolumn(int[,] mat)
    {//fix
    	int sum = 0;
    	int[] sumcol = new int[mat.GetLength(1)];
    	
    	for (int col = 0; col < mat.GetLength(1); col++)
    	{
    		for (int row = 0; row < mat.GetLength(0); row++)
    		{
    			sum += mat[row, col];
    		}
            sumcol[col] = sum;
    		sum = 0;
    	}
    	return sumcol;
    }
