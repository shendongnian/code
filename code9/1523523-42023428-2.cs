	using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public void Main()
		{
			var elements = new List<object> {
				(int)3, (string)"Hello", (int)5, (string)"World"
			};
			var filteredList=GetTypes(typeof(System.String), elements);
			foreach(var x in filteredList) Console.WriteLine($"{x}");
		}
		public List<T> GetTypes<T>(Type type, List<T> elements) 
					=> elements.Where(x => x.GetType() == type).ToList();
	}
