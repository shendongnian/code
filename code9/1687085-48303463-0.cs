    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
    		pairs.Add(Tuple.Create<int, int>(1, 2));
    		pairs.Add(Tuple.Create<int, int>(3, 4));
    		pairs.Add(Tuple.Create<int, int>(3, 5));
    		pairs.Add(Tuple.Create<int, int>(5, 6));
    		pairs.Add(Tuple.Create<int, int>(10, 11));
    		pairs.Add(Tuple.Create<int, int>(2, 3));
    		
    		var results = new List<List<int>>();
    		foreach(var pair in pairs)
    		{
    			var found = false;
    			foreach(var result in results)
    			{
    				var item1Found = result.Contains(pair.Item1);
    				var item2Found = result.Contains(pair.Item2);
    				
    				if(item1Found && item2Found){
    					found = true;
    					break;	
    				}
    				
    				if(item1Found && !item2Found){
    					AddNum(result, results, pair.Item1, pair.Item2);
    					found = true;
    					break;
    				}
    				if(item2Found && !item1Found){
    					AddNum(result, results, pair.Item2, pair.Item1);
    					found = true;
    					break;
    				}
    			}
    			if(!found){
    				results.Add(new List<int> { pair.Item1, pair.Item2 });
    			}
    		}
    		foreach(var result in results)
    		{
    			Console.WriteLine(string.Join(", ", result.OrderBy(i => i).ToArray()));
    		}
    	}
    	
    	public static void AddNum(List<int> result, List<List<int>> results, int existing, int newnum)
    	{
    		result.Add(newnum);
    		foreach(var otherresult in results){
    			if(otherresult != result){
    				if(otherresult.Contains(newnum)){
    					var newresult = result.Concat(otherresult).Distinct().ToArray();
    					result.Clear();
    					result.AddRange(newresult);
    					results.Remove(otherresult);
    					break;	
    				}
    			}
    		}
    	}
    }
