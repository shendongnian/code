	using System;
	class Program
	{
		private static void Main(string[] args)
		{
			DateTime StartTime = DateTime.Now;
			int Seconds = 5;
			int Counter = 0;
		
			while(DateTime.Now - StartTime < TimeSpan.FromSeconds(Seconds))
			{
				//Your Code here?
				Counter++;
			}
		
			Console.WriteLine("In " + Seconds + "seconds are " + Counter + "iterations");
		}
	}
