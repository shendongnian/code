	using System;
						
	public class Program
	{
		public void Main()
		{
			var obj = new Test();
			obj.Count.Dump();
			obj[7].Dump();
		}
		
		
		class Test
		{
			public int Count => 1;
			public string this[int position] => $"2 x {position} = "+ (2*position).ToString();
		}				
	}
