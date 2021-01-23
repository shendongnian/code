    static void Main(string[] args)
            {
                var timeToShutdown = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0).Subtract(DateTime.Now);
    
                var timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = timeToShutdown.TotalMilliseconds;
                timer.Start();
    
                
                Console.WriteLine("Press any key to continue");
                Console.Read();
            }
    
            private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                var timer = (sender as System.Timers.Timer);
                timer.Stop();
                timer.Dispose();
    
                Environment.Exit(0);
            }
