    static bool IsMegaprime(long m)
    {
    	for (long n = m; n != 0; n /= 10)
    		if (!IsPrimeDigit[n % 10]) return false;
    	return IsPrime(m);
    }
