    public class Program
    {
    	public static void Main()
    	{
    		//var x = GetEnumeratorNonGeneric(1);
    		//var x = GetEnumerator(1);
    		//var x = GetEnumeratorInt(1);
    		//var x = GetEnumeratorIntRangeSelect(1);
    		var x = GetEnumeratorIntList(1);
    		
    		for (int i = 0; i < 2; ++i)
    		{
    			var isMoving = x.MoveNext();
    			Console.WriteLine($"Cursor moved: {isMoving}");
    			Console.WriteLine($"Current element is null: {x.Current == null}");
    			Console.WriteLine($"Current element: {x.Current}" );
    		}
    	}
    	
    	static IEnumerator<String> GetEnumerator(int count)
    	{
    		return Enumerable.Range(1, count).Select(n => n.ToString()).GetEnumerator();
    	}
    
    	static IEnumerator<int> GetEnumeratorInt(int count)
    	{
    		return Enumerable.Range(1, count).GetEnumerator();
    	}
    	
		static IEnumerator<int> GetEnumeratorIntRangeSelect(int count)
		{
			return Enumerable.Range(1, count).Select(n => n).GetEnumerator();
		}
	
    	static IEnumerator<int> GetEnumeratorIntList(int count)
    	{
    		return Enumerable.Range(1, count).ToList().GetEnumerator();
    	}
    	
    	static IEnumerator GetEnumeratorNonGeneric(int count)
    	{
    	
    		return new ArrayList(Enumerable.Range(1, count).Select(n => n.ToString()).ToArray()).GetEnumerator();
    	}
    }
