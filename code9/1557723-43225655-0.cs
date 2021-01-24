        static void Main(string[] args)
		{
			int i = 0;
			int j = 1;
			int k;
			checked
			{
				k = i + j;
			}
			unchecked
			{
				k = i + j;
			}
			Console.ReadLine();
		}
