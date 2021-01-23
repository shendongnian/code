    var dict = new Dictionary<Tuple<int, int>, Func<Tuple<int, int>, bool>
    {
       // See how I changed new Tuple... to use Tuple.Create so generic
       // arguments are inferred from usage!
       { Tuple.Create(10000, 25000), Method1 }
       { Tuple.Create(30000, 80000), Method2 }
       { Tuple.Create(85000, 90000), Method3 }
    }.All(pair => pair.Value(pair.Key)); // All methods return true?
    
    // In some class who knows where...
    bool Method1(Tuple<int, int> range)
    {
        return true;
    }
    
    bool Method1(Tuple<int, int> range)
    {
        return true;
    }
    
    bool Method1(Tuple<int, int> range)
    {
        return true;
    }
