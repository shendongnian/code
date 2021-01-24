	public class Program
	{
		public static void Main()
		{
			var a = (0.085 -( 0.0023*(28*(((4400 - 3600)/63)-12.857))));
			var b = (0.085M -( 0.0023M*(28M*(((4400M - 3600M)/63M)-12.857M))));
			
			Console.WriteLine(a);
			Console.WriteLine(b);
			
		}
	}
