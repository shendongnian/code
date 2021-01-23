 	static void Main(string[] args)
    {
		int Height = 4;
		int Width = 5;
		int[,] grid = new int[Height, Width];
		Console.Write("Input Number: ");
		int number = int.Parse(Console.ReadLine());
		Console.Write("input lines offset:");
		int xxof = int.Parse(Console.ReadLine());
		Console.Write("input columns offset:");
		int yyof = int.Parse(Console.ReadLine());
		int[] InputNumber = new int[number];
		InputNumber = Enumerable.Range(1, number).ToArray();
		int t = 0;
		for(int i=xxof;i<Height;i++)
		{
			for(int j=yyof;j<Width;j++)
			{
				grid[i, j] = InputNumber[t];
				t++;
			}
		}
		for (int i = 0; i < Height; i++)
		{
			for (int j = 0; j < Width; j++)
			{
			 Console.Write(grid[i, j]+" ");
			}
			Console.WriteLine();
		}
		Console.ReadKey();
	}
