    void Main()
    {
    	List<A> intList = new List<A> { new A { Id = 2}, new A { Id = 3}, new A { Id = 4}, new A { Id = 5}};
    	
    	List<string> stringList = new List<string>();
    	
    	var propertyArray = intList.First().GetType().GetProperties();
    
    	foreach (var x in intList)
    	{
    		
    		stringList.Add(string.Join(";",propertyArray.Select(y => y.GetValue(x,null))));
    	}
    	
      // Print StringList    
    }
    
    public class A
    {
    	public int Id { get; set;}
    }
