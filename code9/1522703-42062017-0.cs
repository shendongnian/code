     void Main()
        {
        		var groups = new[] { 0, 0, 1, 1, 0,30,1,1,1,1,1 , 22, 22, 15,15,0,0,0,0,0,0 }.GroupConsecutive();
        
        groups.Dump();
        		var maxGroupped = groups.GroupBy(i => i.First()).Select(i => new
        		{
        		       i.Key,
        		       Count = i.Max(j => j.Count())
        		});
        
        foreach (var g in maxGroupped)
               Console.WriteLine(g.Count + " times " + g.Key);
        }
        
         public static class Extension
            {
        	
                public static IEnumerable<IEnumerable<T>> GroupConsecutive<T>(this IEnumerable<T> list) 
                {
                    var group = new List<T>();
                    foreach (var value in list)
                    {
                        if (group.Count == 0 || value.Equals(group[group.Count-1])) 
                            group.Add(value);
                        else
                        {
                            yield return group;
                            group = new List<T> {value};
                        }
                    }
                    yield return group;
                }
