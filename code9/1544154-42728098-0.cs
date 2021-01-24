	using System.IO;
	using System;
	using System.Collections.Generic;
	class Program
	{
		static void Main()
		{
			var x = Divide(2, 50, 5);
			foreach(var y in x) Console.WriteLine("{0}:{1}", y.Item1, y.Item2);
		}
		private static List<Tuple<ulong, ulong>> Divide(ulong min, ulong max, ulong parts) 
		{
			ulong stepSize = (max - min) / parts;
			if (stepSize <= 0) return null;
			
			ulong mod = (max - min) % parts;
			var result = new List<Tuple<ulong, ulong>>();
			ulong begin = min;
			ulong end;
			for (ulong i = 0; i < parts; i++) 
			{
				end = begin + stepSize;
				if (mod > 0)
				{
					mod--;
					end += 1;
				}
				var t = new Tuple<ulong, ulong>(begin, end);
				result.Add(t);
				begin = end;
			}
			return result;
		}
	}
