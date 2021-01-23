    using System;
    using System.Data;
    using System.Linq;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var DS = new DataSet();
    			DS.Tables.Add();
    			DS.Tables[0].Columns.Add("ItemID", typeof(int));
    			DS.Tables[0].Columns.Add("OrderID", typeof(int));
    			DS.Tables[0].Columns.Add("ItemName");
    			DS.Tables[0].Rows.Add(1, 12, "Item1");
    			DS.Tables[0].Rows.Add(1, 12, "Item1");
    			DS.Tables[0].Rows.Add(1, 13, "Item1");
    			DS.Tables[0].Rows.Add(1, 13, "Item1");
    			DS.Tables[0].Rows.Add(2, 12, "Item1");
    			DS.Tables[0].Rows.Add(2, 13, "Item1");
    			DS.Tables[0].Rows.Add(2, 13, "Item1");
    			DS.Tables[0].Rows.Add(3, 13, "Item1");
    			DS.Tables[0].Rows.Add(3, 13, "Item1");
    			DS.Tables[0].Rows.Add(3, 13, "Item2");
    			DS.Tables[0].Rows.Add(3, 13, "Item1");
    
    			var results = DS.Tables[0].AsEnumerable()
    				.GroupBy(x => new
    				{
    					ItemID = x.Field<int>(0),
    					OrderID = x.Field<int>(1)
    				})
    				.Select(x =>
    				{
    					var t = new DataTable();
    					t.Columns.Add("ItemName");
    					x.ToList().ForEach(y => t.Rows.Add(y.Field<string>(2)));
    					return new { x.Key, Table = t };
    				});
    
    			foreach (var i in results)
    			{
    				Console.WriteLine("\n[ ItemID: " + i.Key.ItemID + ", OrderID: " + i.Key.OrderID + " ]");
    				foreach (var row in i.Table.AsEnumerable())
    					Console.WriteLine("  " + row[0]);
    			}
    
    			Console.WriteLine("\nPress any key...");
    			Console.ReadKey();
    		}
    	}
    }
