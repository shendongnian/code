    public static int[] sumcolumn(int[,] mat)
    {
    	int[] sumcol = new int[mat.GetLength(1)];
    	
    	for (int col = 0; col < mat.GetLength(1); col++)
    	{
    		for (int row = 0; row < mat.GetLength(0); row++)
    		{
                 // since sumcol is initially filled with zeros you can just  
                 // sum up the values from mat onto the zeros in each cell
    			sumcol[col] += mat[row, col];
    		}
    	}
    	return sumcol;
    }
