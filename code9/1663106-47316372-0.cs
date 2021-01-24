	using System;
	using System.Linq;
	using System.Collections.Generic;
						
	public class Program
	{
		static public void HistogramLogic(List<Tuple<int[], int[], int[]>> separateRGB)
		{
			var rArray = separateRGB.SelectMany(obj => obj.Item1).ToArray();
			var gArray = separateRGB.SelectMany(obj => obj.Item2).ToArray();
			var bArray = separateRGB.SelectMany(obj => obj.Item3).ToArray();
			
			Console.WriteLine("rArray contains {{{0}}}", string.Join(",", rArray));
			Console.WriteLine("gArray contains {{{0}}}", string.Join(",", gArray));
			Console.WriteLine("bArray contains {{{0}}}", string.Join(",", bArray));
		}
		public static void Main()
		{
            //Mock data
			var input = new List<Tuple<int[], int[], int[]>>
			{
				Tuple.Create(new [] {11,12,13}, new [] {14,15,16}, new [] {17,18,19}),
				Tuple.Create(new [] {21,22,23}, new [] {24,25,26}, new [] {27,28,29}),
				Tuple.Create(new [] {31,32,33}, new [] {34,35,36}, new [] {37,38,39})
				
			};
			HistogramLogic(input);
		}
	}
