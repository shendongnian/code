    using System;	
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		IQueryable<Entity> data = (new List<Entity>() {
    			new Entity { Status = "1", Week = "a"},
    				new Entity { Status = "2", Week = "c"},
    				new Entity { Status = "3", Week = "b"},
    				new Entity { Status = "1", Week = "a"},
    				new Entity { Status = "1", Week = "a"}	
    		}) .AsQueryable();;
    		
    		
    		
    		var result = new List<EntityResult>();
    		
    		var statuses = data.Select(a => a.Status).Distinct().ToList();
    		var weeks = data.Select(a => a.Week).Distinct().ToList();
    		
    		statuses.ForEach(s => {
    			weeks.ForEach( w => {
    				int count = data.Where(a => a.Status == s && a.Week == w).Count();
    				
    				result.Add(new EntityResult { Status = s, Week = s, Count= count});
    			});
    		});
    		
    		
    		Console.WriteLine(result[0].Count);
    	}
    	
    	
    	
    }
    
    public class Entity 
    {
    	public string Status;
    	
    	public string Week;
    }
    						 
    public class EntityResult
    {
    	
    	public string Status;
    	
    	public string Week;
    	
    	public int Count;
    }
