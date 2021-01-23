    void Main()
    {
    	List<Test> link = Test.FetchList();
    
    	var result = link.Select((x, i) => new { x.Prop1, x.Prop2, index = i })
    					 .Max(y => new Result {value = Math.Abs(y.Prop1 - y.Prop2), index = y.index});
    					 
    	result.Dump(); // In this case result would be index 2
    					 
    }
    
    public class Test
    {
    	public int Prop1 { get; set;}
    	
    	public int Prop2 { get; set;}
    
    	public static List<Test> FetchList()
    	{
          var returnList = new List<Test>();
    
    		returnList.Add(new Test { Prop1 = 1, Prop2 = -5});
    		returnList.Add(new Test { Prop1 = 2, Prop2 = -5});
    		returnList.Add(new Test { Prop1 = 1, Prop2 = -9});
    		returnList.Add(new Test { Prop1 = 3, Prop2 = -2});
    		returnList.Add(new Test { Prop1 = 21, Prop2 = 15});
    	  
    	  return (returnList);
    	}
    	
    }
    
    public class Result : IComparable<Result>
    {
    	public int value { get; set; }
    
    	public int index { get; set; }
    	
    	public int CompareTo(Result other)
    	{
    	   return (value - other.value);
    	}
    }
