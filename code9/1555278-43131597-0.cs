    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    public class Program
    {
    	public static void Main()
    	{
    		List<Thing> thingList = new List<Thing>();
    		for (int i = 0; i < 99; i++)
    		{
    			thingList.Add(new Thing(i));
    		}
           int count = 20;
    		int pageIndex = 0;
    		int numberPages = (int)Math.Ceiling(thingList.Count * 1.0/ (count ));
    		for( ; pageIndex < numberPages; pageIndex ++)
    		{
    		   var myPagedThings = GetThings(thingList, count, pageIndex);
    		   foreach( var item in myPagedThings)
    		   {
    			Console.WriteLine(item.ID  );
    		   }
    		}
    	}
    
    	public static IEnumerable<Thing> GetThings(List<Thing> myList, int count, int pageIndex)
    	{
    		var things = (
    			from t in myList
    			select new Thing{ID = t.ID}).ToList();
    		
    		return things.Skip(count * pageIndex).Take(count);
    	}
    }
    
    public class Thing
    {
    	public int ID
    	{ get; set;	}
    
    	public Thing (){}
    	public Thing(int id)
    	{ 	this.ID = id; 	}
    }
