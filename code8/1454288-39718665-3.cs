	using System;
	namespace ConsoleApplication
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				var revision = new RevisionNumber();
				for (int i = 0; i < 100; i++)
				{
					Console.WriteLine(revision);
					revision.Increment();
				}
				Console.ReadKey();
			}
		}
	}
