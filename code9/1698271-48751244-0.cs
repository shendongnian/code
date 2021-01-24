	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Throwing error");
				ThrowException();
			}
			catch (InvalidOperationException e)
			{
				Console.WriteLine(e.Message);
			}
			Console.ReadKey(true);
		}
		static void ThrowException()
		{
			throw new InvalidOperationException("Blah blah blah");
		}
	}
