    public static T[,] Make2DArray<T>(T[] input, int height, int width)
    {
    	T[,] output = new T[height, width];
    	for (int i = 0; i < height; i++)
    	{
        	for (int j = 0; j < width; j++)
        	{
                output[i, j] = input[i * width + j];				
				Console.Write(output[i, j] + "\t" );
        	}
			Console.WriteLine("");
    	}
    	return output;
	}
	public static void Main()
	{		
		// Two-dimensional array.
        int[,] input = new int[,] { { 1, 2, 3}, {4, 5, 6 }, { 7, 8, 9 } };
        var results = from item in input.Cast<int>()
                select item > 3? 1: 0;		
		foreach(var item in  results)
			Console.Write(item + " ");
		Console.WriteLine("");
		var output = Make2DArray(results.ToArray(), 3,3);
	}
    //Output:
    0    0    0    
    1    1    1    
    1    1    1
