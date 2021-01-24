    using System;
	using Newtonsoft.Json;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Example #1");
			string retVal = "{\"txtEmpNoTo\":123,\"Name\":\"Leonel Messi\"}";
			Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(retVal);
			foreach(var item in values)
			{
				Console.WriteLine(item.Value);
			}
			Console.WriteLine("");
			
			Console.WriteLine("Example #2");
			retVal = "{\"txtEmpNoTo\":123,\"Name\":\"Leonel Messi\",\"Team\":\"FC Barcelona\"}";
			values = JsonConvert.DeserializeObject<Dictionary<string, string>>(retVal);
			foreach(var item in values)
			{
				Console.WriteLine(item.Value);
			}
			Console.WriteLine("");
			
			Console.WriteLine("Example #3");
			retVal = "{\"txtEmpNoTo\":123,\"Name\":\"Leonel Messi\",\"Team\":\"FC Barcelona\",\"Squad Number\":10,\"Date of Birth\":\"24-Jun-1987\"}";
			values = JsonConvert.DeserializeObject<Dictionary<string, string>>(retVal);
			foreach(var item in values)
			{
				Console.WriteLine(item.Value);
			}
		}
	}
