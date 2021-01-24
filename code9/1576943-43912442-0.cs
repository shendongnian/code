    using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			var data = new Dictionary<string, List<string>>();
			data.Add("Id", new List<string> { "3", "5", "3" });
			data.Add("Name", new List<string> { "A", "B", "C" });
			
			//var a = data["Id"].FindIndex(b => b == "3");
			
			int[] indexs = data["Id"].Select((b,i) => b == "3" ? i : -1).Where(i => i != -1).ToArray();
			
			foreach(var index in indexs)
			{
				Console.WriteLine(data["Name"][Convert.ToInt16(index)]);
			}	
		}
	}
