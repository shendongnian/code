	class MainClass
	{
		public static void Main(string[] args)
		{
			printAll(new int[] { 2, 2, 4});
			printAll(new int[] { 3, 3, 4, 5, 6 });
		}
		public static void printAll(int[] array)
		{
			int max = 1;
			for (int i = 0; i < array.Length; i++)
			{
				max *= array[i];
			}
			for (int row = 0; row < max; row++)
			{
				int[] line = new int[array.Length];
				int weight = 1;
				for (int j = 0; j < array.Length; j++)
				{
					int times = row / weight;
					// line[j] = times % array[j]; // but you want to start form 1 
                    line[j] = 1 + (times % array[j]); 
					weight *= array[j];
				}
				Console.WriteLine(String.Join(",", line));
			}
		}
	}
