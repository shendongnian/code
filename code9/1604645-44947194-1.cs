    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var data = new List<ILLNESS_OBJECT>{
    			    new ILLNESS_OBJECT{ ID = 1, Parity = 1, Day = DateTime.Now, SomeString = "1", Long = 2L},
    				new ILLNESS_OBJECT{ ID = 2, Parity = 2, Day = DateTime.Now, SomeString = "1", Long = 2L},
    				new ILLNESS_OBJECT{ ID = 3, Parity = 1, Day = DateTime.Now, SomeString = "2", Long = 1L},
    				new ILLNESS_OBJECT{ ID = 4, Parity = 1, Day = DateTime.Now, SomeString = "3", Long = 3L},
    		};
    		Console.WriteLine(GetIllnessRateByParity(data, 1, x => x.ID));
    		Console.WriteLine(GetIllnessRateByParity(data, 1, x => int.Parse(x.SomeString)));
    		Console.WriteLine(GetIllnessRateByParity(data, 1, x => (DateTime.Now - x.Day).Days + 1));
    		Console.WriteLine(GetIllnessRateByParity(data, 1, x => (int)x.Long));
    	}
    	
    	public static IConvertible GetIllnessRateByParity(IEnumerable<ILLNESS_OBJECT> pItems, int pParity, Func<ILLNESS_OBJECT, int> pSelector)
        {
            var filtered = pItems.Where(a => a.Parity == pParity);
            return Math.Round(filtered.Count(a => pSelector(a) == 1)/(double)1, 2);
        }
    	
    }
    
    public class ILLNESS_OBJECT
    {
        public int ID { get; set; }
        public DateTime Day { get; set; }
        public int Parity { get; set; }
        public int Afterbirth { get; set; }
    	public string SomeString { get; set; }
    	public long Long { get; set; }
    }
