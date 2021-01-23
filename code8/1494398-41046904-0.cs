    static void Diagonal(int rows, int cols, Apply action)
    {
    	int k = 0;
    	int row = 0;
    	int col = 0;
    	int length = rows * cols;
    	while (k < length)
    	{
    		action(row, col, k);
    		if ((row + col) % 2 == 0)
    		{
    			if ((row == 0) && (col != cols - 1)) { col++; }
    			else
    			{
    				if (col == cols - 1) { row++; }
    				else { row--; col++; }
    			}
    		}
    		else
    		{
    			if ((col == 0) && (row != rows - 1)) { row++; }
    			else
    			{
    				if (row == rows - 1) { col++; }
    				else { row++; col--; }
    			}
    		}
    		k += 1;
    	}
    }
