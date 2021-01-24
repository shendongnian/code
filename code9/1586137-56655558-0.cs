    public IList<(int example, string descrpt)> ReturnTuples()
    {
       return Enumerable.Range(0, 10)
       		.Select(i => (i, $"{i}"))
    		.ToList();
    }
    var list = ReturnTuples();
    // Again, access each item.example and item.descrpt
