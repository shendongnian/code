    List<long> primeNumbers = new List<long>() { 2 };
    for (long i = 3; i < long.MaxValue; i += 2)
    {
        if(!primeNumbers.Any(p => (i % p) == 0))
        {
            primeNumbers.Add(i);
            if (primeNumbers.Count == 10001)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
