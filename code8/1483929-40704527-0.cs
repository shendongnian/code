    public class Program
    {
    	static IEnumerable<List<MyObj>> Get()
    	{
    		yield return new List<MyObj>();
    		yield return new List<MyObj>();
    	}
    
    	static void Main()
    	{
    		IEnumerable<List<MyObj>> myObjGroups = Get();
    	
    		var result = myObjGroups.Cast<IEnumerable<IMyInterface>>();
    	
    		foreach(var val in result)
    			Console.WriteLine(val.Count());
    	}
    }
