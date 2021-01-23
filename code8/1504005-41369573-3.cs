	bool Test(int input)
    {
        var foundPair = new Dictionary<Tuple<int, int>, Func<Tuple<int, int>, int, bool>>
        {
           // See how I changed new Tuple... to use Tuple.Create so generic
           // arguments are inferred from usage!
           { Tuple.Create(10000, 25000), Method1 },
           { Tuple.Create(30000, 80000), Method2 },
           { Tuple.Create(85000, 90000), Method3 }
        }
        .SingleOrDefault(pair => pair.Key.Item1 >= input && pair.Key.Item2 <= input);
        
        // If this "if" evaluates true, it would mean that no range could be
        // found
        if(!foundPair.Equals(default(KeyValuePair<Tuple<int, int>, Action<Tuple<int, int>, int>>)))
        {
            return foundPair.Value(foundPair.Key, input);
        }
        else
        {
            throw new InvalidOperationException("Input couldn't match any of configured ranges");
        }
    }
		   
	// What happens above? Let's explain it!
    // (1) We create a dictionary to match certain range with a method 
    //     associated with it
    // (2) We look for a pair owning a range within the given integer input
    // (3) If some could be found, then we proceed to call the associated 
    //     delegate giving the range and input as arguments!
    // * NOTE: We need to check if retrieved pair isn't key-value pair default
    //         value because it's an structure (value type).    
    // In some class who knows where...
	bool Method1(Tuple<int, int> range, int input)
    {
        return true;
    }
    
    bool Method2(Tuple<int, int> range, int input)
    {
        return true;
    }
    
    bool Method3(Tuple<int, int> range, int input)
    {
        return true;
    }
