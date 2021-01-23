    using Newtonsoft.Json; /* need to Newtonsoft.Json - NuGet Package */
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string menudata = @"[
            {
                ""MenuId"": 1,
                ""ParentMenuId"": 0
            },
            {
                ""MenuId"": 2,
                ""ParentMenuId"": 1
            },
            {
                ""MenuId"": 3,
                ""ParentMenuId"": 0
            },
            {
                ""MenuId"": 4,
                ""ParentMenuId"": 3
            },
            {
                ""MenuId"": 5,
                ""ParentMenuId"": 4
            },
            {
                ""MenuId"": 6,
                ""ParentMenuId"": 3
            },
            {
                ""MenuId"": 7,
                ""ParentMenuId"": 1
            },
            {
                ""MenuId"": 8,
                ""ParentMenuId"": 4
            }
        ]";
    
    			Console.WriteLine(menudata);
    
    			var r = JsonConvert.DeserializeObject<List<Menu>>(menudata);
    			r = RecursiveTreeSort(r);
    			Console.WriteLine(JsonConvert.SerializeObject(r, Formatting.Indented));
    			Console.ReadLine();
    
    		}
    
    		public static List<Menu> RecursiveTreeSort(List<Menu> source, int parentMenuId = 0)
    		{
    			List<Menu> result = new List<Menu>();
    			foreach (var item in source.Where(s => s.ParentMenuId == parentMenuId))
    			{
    				result.Add(item);
    				result.AddRange(RecursiveTreeSort(source, item.MenuId));
    			}
    			return result;
    		}
    	}
    
    
    	public class Menu
    	{
    		public Menu() { }
    		public int MenuId { get; set; }
    		public int ParentMenuId { get; set; }
    	}
    
    }
