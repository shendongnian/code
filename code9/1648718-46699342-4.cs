	public class Program
	{
        private static readonly rng = new System.Random();
		public static string RandomNumber()
		{
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
