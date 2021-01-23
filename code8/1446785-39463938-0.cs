    static void Main()
        {
            Console.WriteLine("Enter a number");
            var numberToSum = Convert.ToInt32(Console.ReadLine());
            var primesInRange = GetPrimesUpTo(numberToSum);
            var foundSolutions = primesInRange.SubSetsOf().Where(prime => prime.Sum() == numberToSum);
            foreach (var solution in foundSolutions.ToList())
            {
                var formatOperation = solution
                    .Select(x => x.ToString())
                    .Aggregate((a, n) => a + " + " + n) + " = " + numberToSum;
                Console.WriteLine(formatOperation);
            }
            Console.ReadLine();
        }
        public static IEnumerable<int> GetPrimesUpTo(int end)
        {
            var primes = new HashSet<int>();
            for (var i = 2; i <= end; i++)
            {
                var ok = true;
                foreach (var prime in primes)
                {
                    if (prime * prime > i)
                        break;
                    if (i % prime == 0)
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                    primes.Add(i);
            }
            return primes;
        }
        public static IEnumerable<IEnumerable<T>> SubSetsOf<T>(this IEnumerable<T> source)
        {
            if (!source.Any())
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
            var element = source.Take(1);
            var haveNots = SubSetsOf(source.Skip(1));
            var haves = haveNots.Select(set => element.Concat(set));
            return haves.Concat(haveNots);
        }
