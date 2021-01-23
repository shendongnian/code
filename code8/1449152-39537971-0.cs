    static Stopwatch watch = new Stopwatch();
            static void Main(string[] args)
            {
                while (true)
                {
                    startWatch();
                    for (Console.ReadKey(true); ;)
                    {
                        string elptime = stopwatch();
                        Console.WriteLine(elptime);
                        break; // to exit for and startWatch() again.
                    }
                }
            }
          
            static public void startWatch()
            { 
                watch.Start();
            }
            public static string stopwatch()
            {
                String elapsedTime = "";
                TimeSpan ts = watch.Elapsed;
                elapsedTime = String.Format("{0:0}.{1:000}", ts.Seconds, ts.Milliseconds / 1000);
                return elapsedTime;
            }
