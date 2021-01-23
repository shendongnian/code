    bool Test(int input)
    {
        return (bool)new Dictionary<Tuple<int, int>, Func<Tuple<int, int>, int, bool>>
        {
           // See how I changed new Tuple... to use Tuple.Create so generic
           // arguments are inferred from usage!
           { Tuple.Create(10000, 25000), Method1 }
           { Tuple.Create(30000, 80000), Method2 }
           { Tuple.Create(85000, 90000), Method3 }
        }
        .SingleOrDefault(pair => pair.Key.Item1 >= input && pair.Key.Item2 <= input)
        ?.All(pair => pair.Value(pair.Key, input)); // All methods return true?
    }
    
    // In some class who knows where...
    bool Method1(Tuple<int, int> range, int input)
    {
        return true;
    }
    
    bool Method1(Tuple<int, int> range, int input)
    {
        return true;
    }
    
    bool Method1(Tuple<int, int> range, int input)
    {
        return true;
    }
