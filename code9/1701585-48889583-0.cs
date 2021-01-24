    public class helper
    {
        Timer timer = new Timer();
        private int counter = 0;
        private int returnCode = 0;
        private bool timerWorking = false;
        public int Process()
        {
            SetTimer();
            Console.WriteLine("The application started ");
            while(timerWorking){}
            return counter;
        }
        public void SetTimer()
        {
            // All the staff you already have
            timerWorking = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e, int optionalWay)
        {
            counter++;
            Console.WriteLine("Timer is ticking");
            if (counter == 10)
            {
                //All the staff you already have
                timerWorking = false;
            }
        }
    }
