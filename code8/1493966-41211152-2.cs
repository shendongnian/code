    public class Timer
    {
        private timer = new System.Timers.Timer();
        private bool _guard = false;
        // stops the timer and waits until OnTick returns and lock releases.
        // timer can safely pause it self within OnTick.
        // if user request to pause from another thread, full pause is ensured
        public void Stop()       
        {
            timer.Pause();
            lock (this) // reference of timer. it wont dead lock
            {
                // do nothing and wait for OnTick().
            }
        }
        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            if(_gaurd) return;
            lock (this) // lock per instance
            {
                _gaurd = true;
                if (!_timer.Enabled) return;
    
                OnTick(); // somewhere inside here timer may pause it self.
    
                _gaurd = false;
            }
        }
    }
