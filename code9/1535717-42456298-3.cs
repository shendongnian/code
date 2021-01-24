    static IEnumerable<long> MegaprimeNumbers(long start, long end)
    {
    	return PossibleMegaprimeNumbers(start, end)
    		.AsParallel()
    		.Where(IsPrime);
    }
