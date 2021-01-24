	using System;
						
	public class Program
	{
		public static void Main()
		{
			for(int i = 0; i <= 100; i++)
			{
				var guid = Guid.NewGuid();
				var bytes = guid.ToByteArray();
				var rawValue = BitConverter.ToInt64(bytes, 0);
				var inRangeValue = Math.Abs(rawValue) % DateTime.MaxValue.Ticks;
				var date = new DateTime(inRangeValue);
				
				Console.WriteLine(date);
			}
		}
	}
