    // Bad code, do not use
    public class BigLoop
    {
        private static bool keepRunning = true;
        public void TightLoop()
        {
            while (keepRunning)
            {
            }
        }
        public void Stop()
        {
            keepRunning = false;
        }
    }
