    static void Main(string[] args)
    {
    	int n = 0;
    
    	Console.WriteLine("This program prints all prime numbers till a number you specify.\n");
    	Console.Write("Find primes till which number? ");
    
    	var b = int.TryParse(Console.ReadLine(), out n);
    	if (!b) return;
    
    	var stopwatch = new Stopwatch();
    	stopwatch.Start();
    	var primesTillN = FindPrimesTill(n);
    	stopwatch.Stop();
    	var millisecondsToFind = stopwatch.ElapsedMilliseconds;
    	var numFound = primesTillN.Count();
    
    	Console.WriteLine($"\n{numFound} primes between 1 and {n}. Time taken to find primes: {millisecondsToFind} milliseconds");
    	Console.WriteLine("Printing...\n");
    
    	stopwatch.Reset();
    	stopwatch.Start();
    	primesTillN.Print();
    	stopwatch.Stop();
    	var millisecondsToPrint = stopwatch.ElapsedMilliseconds;
    
    	Console.WriteLine($"\n\nSTATS:\nTime to find {numFound} primes between 1 to {n}: {millisecondsToFind} milliseconds.");
    	Console.WriteLine($"Time taken to print: {millisecondsToFind} milliseconds.\n");
    	
    	Console.ReadKey();
    }
