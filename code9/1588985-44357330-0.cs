    void Main()
    {
    	var stringMatrix = ReadAndFillMatrix<string>(s => s);
    	var intMatrix = ReadAndFillMatrix<int>(int.Parse);
    	var doubleMatrix = ReadAndFillMatrix<double>(double.Parse);
    }
    
    private static T[,] ReadAndFillMatrix<T>(Func<string,T> sectionParser)
    {
    	var readAndSplit =
    		new Func<string[]>(
    			() =>
    			{
    				return
    				Console.ReadLine()
    				.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
    				.ToArray();
    			});
    			
    	var size = readAndSplit();
    	var rows = int.Parse(size[0]);
    	var cols = int.Parse(size[1]);
    	
    	var matrix = new T[rows, cols];
    	for (var i = 0; i < rows; i++)
    	{
    		var line = readAndSplit();
    		for (var j = 0; j < cols; j++)
    		{
    			matrix[i,j] = sectionParser(line[j]);
    		}
    	}
    	return matrix;
    }
