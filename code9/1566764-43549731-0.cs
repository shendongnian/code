    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Test
    {
    	public static void Main()
    	{
    		var tuple1 =
                new Tuple<string, string, int>("Man City", "Stoke City", 3);
            var tuple2 =
                new Tuple<string, string, int>("Man Unted", "Liverpool", 2);
            var tuple3 =
                new Tuple<string, string, int>("Barcelona", "Arsenal", 1);
            
            var championsLeague = new List<Tuple<string, string, int>>();
            championsLeague.Add(tuple1);
            championsLeague.Add(tuple2);
            championsLeague.Add(tuple3);
            
            var lst = championsLeague.OrderByDescending(x => x.Item3).Select(x=> x.Item1);
            
            lst.ToList().ForEach(Console.WriteLine);
            
            
    	}
    }
