	using System;
	using System.Text;
						
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine( CreateRandomShape(10, 5) );
		}
		
		public static string CreateRandomShape(int width, int height) {
			StringBuilder output = new StringBuilder();
			for (int y = 0; y < height; y++) {
				if (y == 0) {
					output.AppendLine(new String('0', width));
				} else {
					output.AppendLine(new String(' ', width / 2) + "*");
				}
			}
			return output.ToString();
		}
	}
