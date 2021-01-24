    public static int[] sumColumn(int[,] mat)
    {
    	//int sum = 0;
    	int colCount = mat.GetLength(0);
    	int[] sumCol = new int[colCount];
    	
    	for (int y = 0; y < colCount; y++)
    	{
    		int rowCount = mat.GetLength(1);
    		sumCol[y] = 0;
    		
    		for (int x = 0; x < rowCount; x++)
    		{
    			sumCol[y] += mat[y, x];
    		}
    		
    		//sum += sumCol[y];
    	}
    	
    	//return sum;
        return sumCol;
    }
