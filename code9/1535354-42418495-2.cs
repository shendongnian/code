    static void Main(string[] args)
        {
           DateTime start = DateTime.Now;
           
           var max = 2000000;// Math.Pow(10, 15);
           int slices = 5;
           SlicerMain(slices, max);
           
           Console.WriteLine(counter);
           TimeSpan duration = DateTime.Now - start;
           Console.WriteLine(duration.TotalMilliseconds);
                
           Console.ReadLine();
       }
    /// <summary>
    /// It slices the big number into smaller ones
    /// </summary>
    /// <param name="slices">Total Number of slices</param>
    /// <param name="max">Big number</param>
    public static void SlicerMain(int slices, double max)
        {
           Parallel.For(0, slices,
                        index =>
                             {
                                 double up = max * (index + 1) / slices;
                                 double low = max * (index) / slices + 1;
                                 Interlocked.Add(ref counter, PrimCounter(low, up));
                             });
        }
    /// <summary>
    /// Optimized Prime Counter
    /// </summary>
    /// <param name="first">slice lower bound</param>
    /// <param name="last">slice uper bound</param>
    /// <returns>Count of prime numbers</returns>
    public static int PrimCounter(double first, double last)
            {
                int localCounter = 0;
                for (double a = first; a < last; a++)
                {
                    bool prime = true;
                    for (int c = 2; c * c <= a; c++)
                    {
                        if (a % c == 0)
                        {
                            prime = false;
                            break;
                        }
                    }
                    if (prime)
                        localCounter++;
                }
                return localCounter;
            }
