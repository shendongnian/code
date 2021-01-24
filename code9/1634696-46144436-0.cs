    static void Main()
    {
    	int n = 8;
    	var solution = new int[8, 8];
    
    	for (int i = 0; i < n; i++)
    	{
    		for (int j = 0; j < n; j++)
    		{
    			solution[i, j] = 0;
    		}
    	}
    	Solve(solution, n);
    }
    
    public static void Solve(int[,] solution, int n)
    {
    	if (placeQueens(solution, 0, n))
    	{
    		Console.WriteLine();
    		for (int i = 0; i < n; i++)
    		{
    			for (int j = 0; j < n; j++)
    			{
    				Console.Write(" " + solution[i, j]);
    			}
    			Console.WriteLine();
    		}
    	}
    	else
    	{
    		Console.WriteLine("No possible solution");
    	}
    }
    
    public static bool placeQueens(int[,] solution, int queen, int n)
    {
    	if (queen == n)
    	{
    		return true;
    	}
    	for (int row = 0; row < n; row++)
    	{
    		if (canPlace(solution, row, queen))
    		{
    			solution[row, queen] = 1;
    
    			Console.WriteLine();
    			for (int i = 0; i < n; i++)
    			{
    				for (int j = 0; j < n; j++)
    				{
    					Console.Write(" " + solution[i, j]);
    				}
    				Console.WriteLine();
    			}
    
    			if (placeQueens(solution, queen + 1, n))
    			{
    				return true;
    			}
    
    			solution[row, queen] = 0;
    		}
    	}
    	return false;
    }
    
    public static bool canPlace(int[,] solution, int row, int col)
    {
    	for (var dx = -1; dx <= 1; dx++)
    	{
    		for (var dy = -1; dy <= 1; dy++)
    		{
    			if (dx == 0 && dy == 0)
    				continue;
    
    			int r = row, c = col;
    
    			while (r >= 0 && r <= solution.GetUpperBound(0) && c >= 0 && c <= solution.GetUpperBound(1))
    			{
    				if (solution[r, c] == 1)
    					return false;
    
    				r += dy;
    				c += dx;
    			}
    		}
    	}
    	return true;
    }
