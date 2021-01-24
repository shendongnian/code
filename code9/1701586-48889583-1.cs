    public class helper
    {
        Timer timer = new Timer();
        private int counter = 0;
        private int returnCode = 0;
        Action<int> _doAfterTimerEnds
        public void Process(Action<int> doAfterTimerEnds)
        {
            SetTimer();
            _doAfterTimerEnds = doAfterTimerEnds;
            Console.WriteLine("The application started ");
        }
        public void SetTimer()
        {
            int optionalWay = 0;
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += (sender, e) => OnTimedEvent(sender, e, optionalWay);         
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e, int optionalWay)
        {
            counter++;
            Console.WriteLine("Timer is ticking");
            if (counter == 10)
            {
                timer.Stop();
                timer.Dispose();
                returnCode = returnCode + 1;
                _doAfterTimerEnds(returnCode)
            }
        }
    }
    public static void Main()
    {
        helper helper = new helper();
        helper.Process(code => Console.WriteLine("Main " + code.ToString()));
        Console.ReadLine();
    }
