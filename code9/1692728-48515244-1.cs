	using System.Linq;
	using System;
	using System.Collections.Generic;
	
	public class Program
	{
		class Journal { public int ID; public string Name; }
	
		static void T()
		{
			var journals = new List<Journal>
			{
				new Journal{ID = 1, Name = "Tom"}, new Journal{ID = 2, Name = "Jerry"}, 
				new Journal{ID = 1, Name = "Brad"}, new Journal{ID = 3, Name = "Frog"}, 
				new Journal{ID = 1, Name = "Alex"}, new Journal{ID = 2, Name = "Don"}};
		
			var listById = journals
                .GroupBy(j => j.ID)       // grouping into IEnumerable<IGrouping<int,Journal>>
                .Select(i => i.ToList()); // flattening to IEnumerable<List<Journal>
			
			foreach(var list in listById)
				Console.WriteLine(string.Join(",", 
                    list.Select(l => string.Format("ID: {0} -  NAME: {1}", l.ID , l.Name))));
		}
	
		public static void Main()
		{
			T();
		}
	}
