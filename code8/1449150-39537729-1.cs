    public class MyStopWatch
        {
            Stopwatch stopWatch;
            public MyStopWatch()
            {
              stopWatch = new Stopwatch();
              stopWatch.Start();
            }
            public String GetElapsed()
            {
                TimeSpan ts = stopWatch.Elapsed;
                // Format and display the TimeSpan value.
                return String.Format("{0:0}.{1:000}", ts.Seconds, ts.Milliseconds / 1000);
            }
            
        }
    
        static void Main(string[] args)
        {
            MyStopWatch msw = new MyStopWatch();
            for (Console.ReadKey(true); ;)
            {
                Console.WriteLine(msw.GetElapsed());
            }
        }
    }
