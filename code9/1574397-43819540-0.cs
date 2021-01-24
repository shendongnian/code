    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<Brand> brands = new List<Brand>()
    		{
    			
    			new Brand() {Name = "Brand 1", Item = "Item1", Qty = 200}, 
    				new Brand() {Name = "Brand 1", Item = "Item1", Qty = 100}, 
    				new Brand(){Name = "Brand 1", Item = "Item3", Qty = 98}, 
    				new Brand() {Name = "Brand 1", Item = "Item4", Qty = 95}, 
    				new Brand() {Name = "Brand 2", Item = "Item5", Qty = 150}, 
    				new Brand() {Name = "Brand 2", Item = "Item6", Qty = 125}, 
    				new Brand() {Name = "Brand 2", Item = "Item7", Qty = 120}};
    
    		Console.WriteLine("Top items for all ");
    		var topOfAll = brands.OrderByDescending(x => x.Qty).Take(3);		
    		foreach(Brand brand in topOfAll)
    		{
    			Console.WriteLine(brand.Name + " " + brand.Item + " - " + brand.Qty);
    		}
    		
    		IEnumerable<IGrouping<string, Brand>> grouped = brands.GroupBy(x => x.Name);
    		foreach (IGrouping<string, Brand> groupedBrand in grouped)
    		{
    			Console.WriteLine("Top items for " + groupedBrand.Key);
    			IEnumerable<Brand> top = groupedBrand.Select(x => x).OrderByDescending(x => x.Qty).Take(3);
    			foreach (Brand i in top)
    			{
    				Console.WriteLine(i.Name + " " + i.Item + " - " + i.Qty);
    			}
    		}
    	}
    }
    
    public class Brand
    {
    	public string Name
    	{
    		get;
    		set;
    	}
    
    	public string Item
    	{
    		get;
    		set;
    	}
    
    	public int Qty
    	{
    		get;
    		set;
    	}
    }
