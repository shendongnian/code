    class Program
    {
        static System.Timers.Timer t = new System.Timers.Timer();
        static int tokenCounter;
        static void Main(string[] args)
        {
            t.Elapsed += t_Elapsed;
            t.AutoReset = true;            
            var date = (DateTime.Today.AddDays(1).Date - DateTime.Now);
            t.Interval = date.TotalMilliseconds;
            t.Start();
            while (true)
            {
                tokenCounter++;
                Thread.Sleep(10);
                Console.WriteLine(tokenCounter);
            }
        }
        static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tokenCounter = 0;
        }
    }
