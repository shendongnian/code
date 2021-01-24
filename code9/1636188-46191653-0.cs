    public int Solve()
    {
        var result = 0;
        var upperSearchLimit = 1_000_000;
        Console.WriteLine("Building list of primes...");
        ArrayList primes = Utils.BuildListOfPrimes(upperSearchLimit);
        Console.WriteLine(" Done.");
    
        for (var i = 19; i < upperSearchLimit; i += 2)
        {
            if (primes.Contains(i))
            {
                continue;
            }
    
            var j = 0;
            var match = false;
            do
            {
                int tmp;
                var prime = (int)primes[j];
                tmp = i - prime;
                var half = tmp /= 2;
                var squareRoot = (int)Math.Sqrt(half);
                if (tmp == squareRoot * squareRoot)
                {
                    match = true;
                    Console.WriteLine(i + " = " + (int)primes[j] + " + 2 * " + half);
                }
    
                j++;
            } while ((int)primes[j] < i);
                  
            if (match == false)
            {
                Console.WriteLine("No match for " + i);
                result = i;
                break;
            }
        }
    
        return result;
    }
