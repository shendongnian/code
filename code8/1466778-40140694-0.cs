    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(60000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(elapse); // subscribing to the elapse event
            timer.Start(); // start Timer
            Console.ReadLine(); // hold compiler until key pressed
        }
        private static void elapse(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Hy");
        }
    }
