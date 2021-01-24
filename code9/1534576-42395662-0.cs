    public Tuple<string, int> GetValues()
    {
         return Tuple.Create("first",2);
    }
    
    // usage:
    var result = GetValues();
    var theString = result.Item1;
    var theInt = result.Item2;
