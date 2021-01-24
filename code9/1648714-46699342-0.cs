	public class Program
	{
		
		
		public static string RandomNumber()
		{
			var rng = new System.Random();
			var bytes = new byte[8];
			
			rng.NextBytes(bytes);
			
			return Convert.ToBase64String(bytes);
		}
		
		
		public static void Main()
		{
			Console.WriteLine(RandomNumber());
			Console.WriteLine(RandomNumber());
		}
	}
