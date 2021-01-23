    static void Main()
    {
    	var enumerator = MakeId().GetEnumerator();
    	
    	Console.WriteLine(enumerator.Current); // 0
    	enumerator.MoveNext();
    	Console.WriteLine(enumerator.Current); // 1
    	enumerator.MoveNext();
    	Console.WriteLine(enumerator.Current); // 2
    	enumerator.MoveNext();
    }
    
    static IEnumerable<int> MakeId()
    {
      int index = 0;
      while (true)
        yield return ++index;
    }
