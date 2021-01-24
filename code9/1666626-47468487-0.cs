	public static void Main()
	{
		BitArray b = new BitArray(
             "100101010000101"
             .Select(c => c == '0' ? false : true )
              .ToArray()); // create bitarray from string
		
		var trueIndexes =  from idx in Enumerable.Range(0, b.Count-1 )
						   where b.Get(idx) // == true 
			               select idx;
		
		System.Console.WriteLine(string.Join(", ",trueIndexes)); 
	}
