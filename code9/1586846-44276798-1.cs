        private static Timer timer;
        private static Timer oneHourTimer;
        static void Main(string[] args)
        {
            oneHourTimer = new System.Timers.Timer(3600 * 1000);
            timer = new System.Timers.Timer(60 * 1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(CheckEndProcessStatus);
            oneHourTimer.Elapsed += oneHourTimer_Elapsed;
            oneHourTimer.Start();
            timer.Start();
        }
        static void oneHourTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            //maybe stop one hour timer as well here
            oneHourTimer.Stop();
        }
        private static void CheckEndProcessStatus(object source, ElapsedEventArgs args)
        {
            try
            {
                if (CheckFunction())
                {
                    //stop timer
                    timer.Stop();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private static bool CheckFunction()
        {
            bool check = false;
            try
            {
                //some logic to set 'check' to true or false
            }
            catch (Exception ex)
            {
                throw;
            }
            return check;
        }
