    public int CalculateMillionthPrimeNumber()
    {
    	List<int> primes = new List<int>(1000000){2};
    	int num = 3;
    	while(primes.Count < 1000000)
    	{
    		foreach(int div in primes)
    		{
    			if ((num / div) * div == num)
    				goto next;
    		}
    		primes.Add(num);
    		next:
    			++num;
    	}
    	return primes.Last();
    }
