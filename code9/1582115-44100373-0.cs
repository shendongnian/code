	class Program
	{
		public static void Main()
		{
			var clockBuilder = new StringBuilder();
			GenerateSandClock( clockBuilder, 13 );
			Console.Write(clockBuilder.ToString() );
			Console.ReadKey();
		}
	
		private static void GenerateSandClock(StringBuilder stringBuilder, uint height, int indentionLevel = 0)
		{
			var line = NumberToSpaces( indentionLevel ++ ) + NumberToAestrics( height );
			stringBuilder.AppendLine(line);
	
			if (height == 1)
			{
				return;
			}
			GenerateSandClock(stringBuilder, height - 2, indentionLevel);
			stringBuilder.AppendLine(line);
		}
	
		private static string NumberToSpaces( int indentionLevel)
		{
			return new string( ' ', indentionLevel);
		}
	
		private static string NumberToAestrics(uint numberOfAestrics)
		{
			return new string( '*', (int)numberOfAestrics );
		}
	}
