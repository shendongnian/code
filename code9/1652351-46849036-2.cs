    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{	
    		var myIEnumerable = GetMyEnumerable();
    		foreach(var item in myIEnumerable.MyCustomOrderBy(x => x))
    		{			
    			if(item == myIEnumerable.First())
    			{
    				Console.WriteLine("The condition is true with: " + item);
    			}
    		}
    	}	
    	
    	public static IEnumerable<int> GetMyEnumerable()
    	{			
    		foreach(var i in new int[] {5, 4, 3, 2, 1})
    		{
    			Console.WriteLine("GetMyEnumerable was called " + i);	
    			yield return i;
    		}		
    	}		
    }
    
    public static class OrderByExtensionMethod
    {
    	public static IOrderedEnumerable<TSource> MyCustomOrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    	{
    		Console.WriteLine("OrderByExtensionMethod was called");	
    		return source.OrderBy(keySelector);
    	}
    }
