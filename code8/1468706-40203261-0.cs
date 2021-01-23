    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication
    {
    	public partial class Item
    	{
    		public enum MyEnumE
    		{
    			[Description("description of enum1")]
    			Enum1,
    			[Description("description of enum2")]
    			Enum2
    		}
    
    		public Item(MyEnumE myEnum)
    		{
    			MyEnum = myEnum;
    		}
    
    		public MyEnumE MyEnum { get; set; }
    	}
    
    	class Program
    	{
    		private static IEnumerable<KeyValuePair<int, int>> GetEnumRanks(Type enumType)
    		{
    			var values = Enum.GetValues(enumType);
    			var results = new List<KeyValuePair<int, string>>(values.Length);
    
    			foreach (int value in values)
    			{
    				FieldInfo fieldInfo = enumType.GetField(Enum.GetName(enumType, value));
    				var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
    				results.Add(new KeyValuePair<int, string>(value, attribute.Description));
    			}
    
    			return results.OrderBy(x => x.Value).Select((x, i) => new KeyValuePair<int, int>(x.Key, i));
    		}
    
    		static void Main(string[] args)
    		{
    			var itemsList = new List<Item>();
    			itemsList.Add(new Item(Item.MyEnumE.Enum1));
    			itemsList.Add(new Item(Item.MyEnumE.Enum2));
    			itemsList.Add(new Item(Item.MyEnumE.Enum2));
    			itemsList.Add(new Item(Item.MyEnumE.Enum1));
    
    			IQueryable<Item> items = itemsList.AsQueryable();
    
    			var descriptions = GetEnumRanks(typeof(Item.MyEnumE));
    
    			//foreach (var i in descriptions)
    			//	Console.WriteLine(i.Value);
    
    			var results = items.Join(descriptions, a => (int)a.MyEnum, b => b.Key, (x, y) => new { Item = x, Rank = y.Value }).OrderBy(x => x.Rank).Select(x => x.Item);
    
    			foreach (var i in results)
    				Console.WriteLine(i.MyEnum.ToString());
    
    			Console.WriteLine("\nPress any key...");
    			Console.ReadKey();
    		}
    	}
    }
