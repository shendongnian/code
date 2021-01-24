    using System;
    using System.Linq;				
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		var p = new Program();
    		
    		var list = p.CreateEnumerable<int?>(1, 2, 3, 4);
    		p.DoWork(list);    		
    	}
    
    	public void DoWork(IEnumerable<int?> enumerable)
    	{
    		enumerable.ToList().ForEach(x => 
    		{
    			Console.WriteLine(x);
    		});
    	}
    	
    	public IEnumerable<T> CreateEnumerable<T>(params T[] items)
        {
            if (items == null)
                yield break;
    
            foreach (T mitem in items)
                yield return mitem;
        }
    }
