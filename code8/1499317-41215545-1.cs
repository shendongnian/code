    public static void ReplaceValues (int[,] destinationArray, int[,] replaceWith, int columnOffset, int rowOffset)
    {
    	for (int row = 0; row < replaceWith.GetLength (0); row++)
    	{
    	 	for (int column = 0; column < replaceWith.GetLength (1); column++)
    		{
    	 		destinationArray[row + rowOffset, column + columnOffset] = replaceWith[row, column];
	    	}
    	}
    }
