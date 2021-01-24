    private static Timer timer;
        static void Main(string[] args)
        {
            timer = new System.Timers.Timer(60000);
            timer.Elapsed += new
            System.Timers.ElapsedEventHandler(CheckEndProcessStatus);
            //if timer timed out, stop executing the function
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
