    using System;
	using System.Collections.Generic;
	using System.Linq;
				
	public class Program
	{
		public class Stock
		{
			public int Id { get; set; }
			public int? Yellow { get; set; }
			public int? Red { get; set; }
			public int? White { get; set; }
		}
		
		public static void Main()
		{
			List<Stock> list = new List<Stock>();
			list.Add(new Stock(){Id=1, Yellow = 50, Red = 0, White = 205});
			list.Add(new Stock(){Id=2, Yellow = 20, Red = 200, White = 35});
			list.Add(new Stock(){Id=3, Yellow = 0, Red = 100, White = 155});
					
			string ColumnName = "Yellow";
			
			var Test1 = GetColumnValue(list.Where(m=>m.Id == 1).ToList(), ColumnName);
			var Test2 = GetColumnValue(list.Where(m=>m.Id == 2).ToList(), ColumnName);
			var Test3 = GetColumnValue(list.Where(m=>m.Id == 3).ToList(), ColumnName);
			
			Console.WriteLine(Test1);
			Console.WriteLine(Test2);
			Console.WriteLine(Test3);
		}
		
		public static object GetColumnValue(List<Stock> items, string columnName)
		{
			var values = items.Select(x => x.GetType().GetProperty(columnName).GetValue(x)).FirstOrDefault();
			return values;
		}
	}
