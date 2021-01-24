    void Main()
    {
        var pc = new ParallelCalc(20, 5);
        pc.Finished += (sender, args) =>
        {
            Console.WriteLine(args);
        };
        pc.Start();
    }
    
    public class CalcFinishedEventArgs : EventArgs
    {
        public long Result {get; set;}
        public long Time {get; set;}
    }
    
    public class ParallelCalc
    {
        public long MaxNumber { get; set; }
        public int ThreadsNumber { get; set; }
    
        public event EventHandler<CalcFinishedEventArgs> Finished;
    
        public ParallelCalc(long MaxNumber, int ThreadsNumber)
        {
            this.MaxNumber = MaxNumber;
            this.ThreadsNumber = ThreadsNumber;
        }
    
        public void Start()
        {
            var output = new long[ThreadsNumber];
            var threads = new Thread[ThreadsNumber];
            var pendingThreads = ThreadsNumber;
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < ThreadsNumber; i++)
            {
                var index = i;
        		var start = 1 + (i * MaxNumber) / ThreadsNumber;
        		var end = ((i + 1) * MaxNumber) / ThreadsNumber;
                threads[i] = new Thread
                (
                    () =>
                    {
                        output[index] = Sum(start, end);
                        if (Interlocked.Decrement(ref pendingThreads) == 0)
                        {
                            sw.Stop();
                            Finished?.Invoke
                            (
                                this,
                                new CalcFinishedEventArgs()
                                {
                                    Result = output.Sum(),
                                    Time = sw.ElapsedMilliseconds
                                }
                            );
                        }
                    }
                );
        		threads[i].Start();
            }
        }
    
        private static long Sum(long startNumber, long endNumber)
        {
            long result = 0;
            for (long i = startNumber; i <= endNumber; i++)
            {
                result += i;
            }
            return result;
        }
    }
