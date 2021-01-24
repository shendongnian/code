    using System.Linq;
    using System.Collections;
	public static IEnumerable<int> GetTrueIndexes(BitArray arr)
	{
		if (arr != null)		
			return Enumerable.Range(0,arr.Count).Where( idx => arr.Get(idx));
					
		return new int[0];
	}
		
	public static void Main()
	{
		BitArray b = new BitArray(
            "100101010000101"
            .Select(c => c == '0' ? false : true )
            .ToArray());
		
		var trueIndexes =  GetTrueIndexes(b);		
		
		System.Console.WriteLine(string.Join(", ",trueIndexes)); 
	}
