    static void Main()
    {
        var enumerator = MakeId().GetEnumerator();
    
    	enumerator.MoveNext();
        Console.WriteLine(enumerator.Current); // 0    
    	enumerator.MoveNext();
        Console.WriteLine(enumerator.Current); // 1    
    	enumerator.MoveNext();
        Console.WriteLine(enumerator.Current); // 2
        
    }
    
    static IEnumerable<int> MakeId()
    {
      int index = 0;
      while (true)
        yield return index++;
    }
