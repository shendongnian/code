    public class Timer
    {
        private timer = new System.Timers.Timer();
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
